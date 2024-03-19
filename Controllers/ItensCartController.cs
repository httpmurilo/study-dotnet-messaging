using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using study_project.model;
using study_project.repository;

namespace study_project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItensCartController : ControllerBase
    {
        private readonly IItensRepository repository;

        public ItensCartController(IItensRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public  Task<ActionResult<IEnumerable<Itens>>> GetTodoItems()
        {
            return (Task<ActionResult<IEnumerable<Itens>>>)repository.getItens();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Itens>> GetTodoItem(int id)
        {
            var itensExists = repository.getItensById(id);

            if (itensExists == null)
            {
                return NotFound();
            }

            return repository.getItensById(id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutTodoItem(int id, Itens itens)
        {
            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Itens>> PostTodoItem(Itens itens)
        {

            repository.insertItens(itens);
            repository.Save();



            return Ok(itens);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodoItem(int id)
        {
            var itenExist =  repository.getItensById(id);
            if (itenExist == null)
            {
                return NotFound();
            }

            repository.DeleteItens(id);
            repository.Save();

            return NoContent();
        }
    }
}
