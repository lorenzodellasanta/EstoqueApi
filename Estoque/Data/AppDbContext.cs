using Microsoft.EntityFrameworkCore;
using Estoque.Models;

namespace Estoque.Data
{
    public class AppDbContext : DbContext
    {
        protected readonly IConfiguration Configuration;
        public AppDbContext(DbContextOptions<AppDbContext> options, IConfiguration configuration) : base(options)
        {
            Configuration = configuration;
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseNpgsql(Configuration.GetConnectionString("DefaultConnection"));
        }

        public DbSet<Categoria> Categorias { get; set; } = null!;
        public DbSet<Produto> Produtos { get; set; } = null!;

    }
}
