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

// Endpoints Cliente

app.MapGet("/Cliente", async (PharmaContext db, IMapper mapper, [FromQuery] int page, [FromQuery] int pageSize) =>
{

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

app.MapGet("/Cliente/{id}", async (int id, PharmaContext db, IMapper mapper) =>
{
    return await db.Clientes.FindAsync(id)
        is Cliente cliente
            ? Results.Ok(mapper.Map<ClienteSearchDto>(cliente))
            : Results.NotFound();
});

app.MapPost("/Cliente", async (PharmaContext db, IMapper mapper, ClienteCreateDto clienteDto) =>
{
    var cliente = mapper.Map<Cliente>(clienteDto);
    db.Clientes.Add(cliente);

    var raw = await db.SaveChangesAsync();

    if(raw > 0) return Results.Created($"/Cliente/{cliente.Id}", cliente);

    return Results.NoContent();
});

app.MapPut("/Cliente/{id}", async (int id, PharmaContext db, IMapper mapper, ClienteUpdateDto clienteDto) =>
{
    var cliente = await db.Clientes.FindAsync(id);
    if (cliente is null) return Results.NotFound();

    mapper.Map(clienteDto, cliente);
    var raw = await db.SaveChangesAsync();

    return raw > 0 ? Results.Ok(cliente) : Results.NoContent();
});

app.Run();
