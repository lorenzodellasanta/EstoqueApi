using Microsoft.AspNetCore.Mvc;
using Estoque.Data;
using Estoque.Models;

namespace Estoque.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class ProdutosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProdutosController(AppDbContext context)
        {
            _context = context;
        }

        //Lista todos os itens do banco de dados!!!
        [HttpGet]
        public IActionResult ListarProduto()
        {
            return Ok(_context.Produtos.ToList());
        }

        // Busca item especifico do banco de dados!!!
        [HttpGet("{id}")]
        public IActionResult BuscaProduto(int id)
        {
            var produto = _context.Produtos.Find(id);
            if(produto == null)
            {
                return NotFound();
            }

            return Ok(produto);
        }

        [HttpPost]
        public IActionResult CriarProduto(Produto produto)
        {
            _context.Produtos.Add(produto);
            _context.SaveChanges();
            return Ok(produto);
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarProduto(int id, Produto produto)
        {
            if(id!= produto.Id)
            {
                return BadRequest();
            }

            _context.Produtos.Update(produto);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult RemoverProduto(int id)
        {
            var produto = _context.Produtos.Find(id);
            if(produto == null)
            {
                return NotFound();
            }

            _context.Produtos.Remove(produto);
            _context.SaveChanges();
            return NoContent();
        }
    }

}
