using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PharmaFlow.Data;
using PharmaFlow.Data.Dtos;
using PharmaFlow.Models;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("PharmaFlowConnection");
builder.Services.AddDbContext<PharmaContext>(opt => opt.UseSqlServer(connectionString));
builder.Services.AddAutoMapper(cfg => { }, AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

var clientes = app.MapGroup("/Cliente");
var fornecedores = app.MapGroup("/Fornecedor");

// Endpoints Cliente


clientes.MapGet("/", async (PharmaContext db, IMapper mapper, [FromQuery] int page, [FromQuery] int pageSize) =>
{

    page = page < 1 ? 1 : page;
    var totalItems = await db.Clientes.CountAsync();
    var totalPages = (int)Math.Ceiling(totalItems / (double)pageSize);

    var clientes = await db.Clientes
    .Skip((page - 1) * pageSize)
    .Take(pageSize).ToListAsync();
    var clientesDto = mapper.Map<List<ClienteSearchDto>>(clientes);

    var result = new
    {
        Page = page,
        PageSize = pageSize,
        TotalItems = totalItems,
        TotalPages = totalPages,
        Items = clientesDto
    };

    return Results.Ok(result);
});

clientes.MapGet("/{id}", async (int id, PharmaContext db, IMapper mapper) =>
{
    return await db.Clientes.FindAsync(id)
        is Cliente cliente
            ? Results.Ok(mapper.Map<ClienteSearchDto>(cliente))
            : Results.NotFound();
});

clientes.MapPost("/", async (PharmaContext db, IMapper mapper, ClienteCreateDto clienteDto) =>
{
    var cliente = mapper.Map<Cliente>(clienteDto);
    db.Clientes.Add(cliente);

    var raw = await db.SaveChangesAsync();

    if(raw > 0) return Results.Created($"/Cliente/{cliente.Id}", cliente);

    return Results.NoContent();
});

clientes.MapPut("/{id}", async (int id, PharmaContext db, IMapper mapper, ClienteUpdateDto clienteDto) =>
{
    var cliente = await db.Clientes.FindAsync(id);
    if (cliente is null) return Results.NotFound();

    mapper.Map(clienteDto, cliente);
    var raw = await db.SaveChangesAsync();

    return raw > 0 ? Results.Ok(cliente) : Results.NoContent();
});

clientes.MapDelete("/{id}", async (int id, PharmaContext db) =>
{
    var cliente = await db.Clientes.FindAsync(id);

    if (cliente is null) return Results.NotFound();

    db.Clientes.Remove(cliente);
    await db.SaveChangesAsync();

    return Results.NoContent();
});

// Endpoints Fornecedor

fornecedores.MapGet("/", async (PharmaContext db, IMapper mapper, [FromQuery] int page, [FromQuery] int pageSize) =>
{
    page = page < 1 ? 1 : page;
    var totalItems = await db.Fornecedores.CountAsync();
    var totalPages = (int)Math.Ceiling(totalItems / (double)pageSize);
    var fornecedores = await db.Fornecedores
    .Skip((page - 1) * pageSize)
    .Take(pageSize).ToListAsync();
    var fornecedoresDto = mapper.Map<List<FornecedorSearchDto>>(fornecedores);
    var result = new
    {
        Page = page,
        PageSize = pageSize,
        TotalItems = totalItems,
        TotalPages = totalPages,
        Items = fornecedoresDto
    };
    return Results.Ok(result);
});

fornecedores.MapPost("/", async (PharmaContext db, IMapper mapper, FornecedorCreateDto fornecedorDto) =>
{
    var fornecedor = mapper.Map<Fornecedor>(fornecedorDto);
    db.Fornecedores.Add(fornecedor);
    var raw = await db.SaveChangesAsync();
    if(raw > 0) return Results.Created($"/Fornecedor/{fornecedor.Id}", fornecedor);
    return Results.NoContent();
});

fornecedores.MapGet("/{id}", async (int id, PharmaContext db, IMapper mapper) =>
{
    var fornecedor = await db.Fornecedores.FindAsync(id);
    if (fornecedor is null) return Results.NotFound();

    var result = mapper.Map<FornecedorSearchDto>(fornecedor);

    return Results.Ok(result);
});

fornecedores.MapPut("/{id}", async (int id, FornecedorUpdateDto fornecedorDto, PharmaContext db, IMapper mapper) =>
{
    var fornecedor = await db.Fornecedores.FindAsync(id);
    if (fornecedor is null) return Results.NotFound();

    var result = mapper.Map(fornecedorDto, fornecedor);
    await db.SaveChangesAsync();

    return Results.Ok(result);
});

fornecedores.MapDelete("/{id}", async (int id, PharmaContext db) =>
{
    var fornecedor = await db.Fornecedores.FindAsync(id);

    if (fornecedor is null) return Results.NotFound();
    db.Fornecedores.Remove(fornecedor);

    await db.SaveChangesAsync();

    return Results.NoContent();
});

app.Run();
