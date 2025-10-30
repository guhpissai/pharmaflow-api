using Microsoft.EntityFrameworkCore;
using PharmaFlow.Data;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("PharmaFlowConnection");
builder.Services.AddDbContext<PharmaContext>(opt => opt.UseSqlServer(connectionString));

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
