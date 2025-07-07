using MercadinhoAPI.Data;
using MercadinhoAPI.Models;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.MapGet("/produtos", async (AppDbContext db) =>
await db.Produtos.ToListAsync());


app.MapPost("produtos", async (Produto produto, AppDbContext db) =>
{
    db.Produtos.Add(produto);
    await db.SaveChangesAsync();
    return Results.Ok();
});

app.MapPut("/produtos/{id}", async (int id, Produto input, AppDbContext db) =>
{
    var produto = await db.Produtos.FindAsync(id);
    if (produto == null) return Results.NotFound();

    produto.Nome = input.Nome;
    produto.Descricao = input.Descricao;
    produto.Quantidade = input.Quantidade;
    produto.Estoque = input.Estoque;

    await db.SaveChangesAsync();
    return Results.Ok();

});

app.MapDelete("/produtos/{id}", async (int id, AppDbContext db) =>
{
    var produto = await db.Produtos.FindAsync(id);
    if(produto is null) return Results.NotFound();

    db.Produtos.Remove(produto);
    await db.SaveChangesAsync();
    return Results.Ok();
        
});


app.Run();