using LarrainVial.Portafolios.Api.Data;
using LarrainVial.Portafolios.Api.DTOs;
using LarrainVial.Portafolios.Api.Entities;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapPost("/clientes", async (ClienteCreateDto cliente, AppDbContext db) =>
{
    var nuevoCliente = new Cliente
    {
        Nombre = cliente.Nombre,
        Saldo = cliente.Saldo
    };

    db.Clientes.Add(nuevoCliente);
    await db.SaveChangesAsync();

    var respuesta = new ClienteResponseDto
    {
        Id = nuevoCliente.Id,
        Nombre = nuevoCliente.Nombre,
        Saldo = nuevoCliente.Saldo
    };

    return Results.Created($"/clientes/{respuesta.Id}", respuesta);
});

app.MapGet("/clientes", async (AppDbContext db) =>
{
    var clientes = await db.Clientes.ToListAsync();

    var respuesta = clientes.Select(c => new ClienteResponseDto
    {
        Id = c.Id,
        Nombre = c.Nombre,
        Saldo = c.Saldo
    });
    return Results.Ok(respuesta);
});

using (var scope = app.Services.CreateScope())
{
    var db= scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.Migrate();
}

app.Run();
