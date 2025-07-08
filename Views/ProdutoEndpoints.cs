using MercadinhoAPI.Controllers;
using MercadinhoAPI.Data;
using MercadinhoAPI.Data.Models;

namespace MercadinhoAPI.Views;

public static class ProdutoEndpoints
{
    public static void MapEndpointsProduto(this WebApplication app)
    {
        app.MapGet("/produtos", async (AppDbContext db)
            => await ProdutoController.ListarProdutosAsync(db));

        app.MapPost("produtos", async (Produto produto, AppDbContext db)
            => await ProdutoController.AdicionarProdutoAsync(produto, db));

        app.MapPut("/produtos/{id}", async (int id, Produto request, AppDbContext db)
            => await ProdutoController.EditarProdutoAsync(id, request, db));

        app.MapDelete("/produtos/{id}", async (int id, AppDbContext db)
            => await ProdutoController.DeletarProduto(id, db));
    }
}
