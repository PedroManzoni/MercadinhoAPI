using MercadinhoAPI.Data;
using MercadinhoAPI.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace MercadinhoAPI.Controllers;

public static class ProdutoController
{
    public static async Task<List<Produto>> ListarProdutosAsync(AppDbContext db)
      => await db.Produtos.ToListAsync();

    public static async Task<IResult> AdicionarProdutoAsync(Produto produto, AppDbContext db)
    {
        db.Produtos.Add(produto);
        await db.SaveChangesAsync();
        return Results.Ok();
    }

    public static async Task<IResult> EditarProdutoAsync(int id, Produto request, AppDbContext db)
    {

        var produto = await db.Produtos.FindAsync(id);
        if (produto == null) return Results.NotFound();

        produto.Nome = request.Nome;
        produto.Descricao = request.Descricao;
        produto.Quantidade = request.Quantidade;
        produto.Estoque = request.Estoque;

        await db.SaveChangesAsync();
        return Results.Ok();
    }

    public static async Task<IResult> DeletarProduto(int id, AppDbContext db)
    {
        var produto = await db.Produtos.FindAsync(id);
        if (produto is null) return Results.NotFound();

        db.Produtos.Remove(produto);
        await db.SaveChangesAsync();
        return Results.Ok();
    }






}
