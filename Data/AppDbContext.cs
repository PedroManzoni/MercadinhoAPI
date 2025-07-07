using MercadinhoAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace MercadinhoAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Produto> Produtos { get; set; } = null!;
    }
}
