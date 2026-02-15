using Estoque.Data;
using Estoque.Models;

namespace Estoque.Repository
{
    public class CategoriaRepository : Repository<Categoria>, ICategoriaRepository
    {
        private readonly AppDbContext _context;

        public CategoriaRepository(AppDbContext context) : base(context)
        {
            _context = context;


         }


    }
    
}
