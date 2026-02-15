using Estoque.Models;

namespace Estoque.Repository
{
    public interface IProdutoRepository : IRepository<Produto>,IDisposable
    {
        List<Produto>? GetProdutosAndCategoria();
    }
}
