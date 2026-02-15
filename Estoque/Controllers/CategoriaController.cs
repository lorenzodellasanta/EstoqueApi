using Estoque.Models;
using Estoque.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Estoque.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {

        private static ICategoriaRepository _categoriaRepository;

        public CategoriaController(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategoria()
        {
            var categoria = await _categoriaRepository.GetAllAsync();
            return Ok(categoria);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoria(int id)
        {
            var categoria = await _categoriaRepository.GetByIdAsync(id);

            if(categoria is null)
            {
                return NotFound("Categoria não existe");
            }

            return Ok(categoria);
        }

        [HttpPost]
        public async Task<IActionResult> AddCategoria([FromBody]Categoria categoria)
        {
            var novaCategoria =  await _categoriaRepository.GetAllAsync();
            var categoriaExiste = novaCategoria.Where(c => c.Id == categoria.Id);

            if(categoriaExiste is null)
            {
                return NotFound("Categoria não existe");
            }

            _categoriaRepository.Insert(categoria);
            await _categoriaRepository.SaveChangesAsync();

            return Ok(categoria);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategoria(int id, Categoria categoria)
        {
            var categoriaExiste = await _categoriaRepository.GetByIdAsync(id);

            if (categoriaExiste is null)
            {
                return NotFound("Essa Categoria não existe");
            }

            categoriaExiste.Desc = categoria.Desc;

            _categoriaRepository.Update(categoriaExiste);
            await _categoriaRepository.SaveChangesAsync();

            return Ok(categoriaExiste);

        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategoria(int id)
        {
            var categoria = await _categoriaRepository.GetByIdAsync(id);

            if (categoria is null)
            {
                return NotFound("Essa Categoria não existe");
            }

            _categoriaRepository.Delete(categoria);
            await _categoriaRepository.SaveChangesAsync();


            return Ok(categoria);
        }
    }
}
