using Microsoft.EntityFrameworkCore;
using PharmaFlow.Data;
using PharmaFlow.Models;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("PharmaFlowConnection");
builder.Services.AddDbContext<PharmaContext>(opt => opt.UseSqlServer(connectionString));

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("Cliente", async (PharmaContext db) =>
{
    var clientes = await db.Clientes.ToListAsync();
    return Results.Ok(clientes);
}); 

app.MapPost("/Cliente", async (PharmaContext db, Cliente cliente) =>
{
    db.Clientes.Add(cliente);
    await db.SaveChangesAsync();
    return Results.Created($"/Cliente/{cliente.Id}", cliente);
});

app.Run();
