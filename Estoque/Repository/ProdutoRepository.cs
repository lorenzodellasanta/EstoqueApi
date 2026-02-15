using Microsoft.EntityFrameworkCore;
using Estoque.Data;
using Estoque.Models;

namespace Estoque.Repository
{
    public class ProdutoRepository : Repository<Produto>,IProdutoRepository
    {
        private readonly AppDbContext _context;

        public ProdutoRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }


        public List<Produto>? GetProdutosAndCategoria()
        {
            var query = from p in _context.Produtos
                        join c in _context.Categorias on p.IdCategoria equals c.Id
                        select new Produto
                        {
                            Id = p.Id,
                            Nome = p.Nome,
                            Quantidade = p.Quantidade,
                            Preco = p.Preco,
                            Categoria = new Categoria
                            {
                                Id = c.Id,
                                Desc = c.Desc,
                            }
                        };

            return query.ToList();

        }

    }
}
