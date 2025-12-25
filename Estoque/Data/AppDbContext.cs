using Microsoft.EntityFrameworkCore;
using Estoque.Models;

namespace Estoque.Data
{
    public class AppDbContext : DbContext
    {
        
            public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

            public DbSet<Produto> Produtos { get; set; } = null!;

    }
}
