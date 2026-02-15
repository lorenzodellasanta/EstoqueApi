using Microsoft.AspNetCore.Mvc;
using Estoque.Models;
using Estoque.Repository;

namespace Estoque.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutosController : ControllerBase
    {

        private static IProdutoRepository _produtoRepository;
        public ProdutosController(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        //Lista todos os itens do banco de dados!!!
        [HttpGet]
        public async Task<IActionResult>GetAllProdutos()
        {
            var produtos = _produtoRepository.GetProdutosAndCategoria();

            return Ok(produtos);
        }

        // Busca item especifico do banco de dados!!!
        [HttpGet("{id}")]
        public async Task<IActionResult>GetProduto(int id)
        {
            var produto = await _produtoRepository.GetByIdAsync(id);

            if(produto is null)
            {
                return NotFound("Produto não encontrado!");
            }

            return Ok(produto);
        }

        [HttpPost]
        public  async Task<IActionResult> AddProduto(Produto produto)
        {
            var produtos = await _produtoRepository.GetAllAsync();
            var novoProduto = produtos.Where(nProduto => nProduto.Nome == produto.Nome);

            if(novoProduto is null)
            {
                return NotFound("Produto inexistente");
            }

            _produtoRepository.Insert(produto);
            await _produtoRepository.SaveChangesAsync();

            return Ok(produto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduto(int id, Produto produto)
        {
            var produtoAtualizado = await _produtoRepository.GetByIdAsync(id);

            if(produtoAtualizado is null)
            {
                return NotFound("Produto Inexistente");
            }

            produtoAtualizado.Nome = produto.Nome;
            produtoAtualizado.Quantidade = produto.Quantidade;
            produtoAtualizado.Preco = produto.Preco;
            produtoAtualizado.Categoria = produto.Categoria;

            _produtoRepository.Update(produtoAtualizado);
            await _produtoRepository.SaveChangesAsync();

            return Ok(produtoAtualizado);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduto(int id)
        {
            var produto = await _produtoRepository.GetByIdAsync(id);

            if(produto is null)
            {
                return NotFound("Produto Inexistente");
            }

            _produtoRepository.Delete(produto);
            await _produtoRepository.SaveChangesAsync();

            return Ok(produto);
        }
    }

}
