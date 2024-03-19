using Microsoft.AspNetCore.Mvc;
using study_project.db;
using study_project.model;
using study_project.repository;

namespace study_project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartRepository repository;

        public CartController(ICartRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public Task<ActionResult<IEnumerable<Cart>>> GetCartItems()
        {
            return (Task<ActionResult<IEnumerable<Cart>>>)repository.GetCarts();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Cart>> GetCartItem(int id)
        {
            var CartExists = repository.getCartById(id);

            if (CartExists == null)
            {
                return NotFound();
            }

            return repository.getCartById(id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> putCart(int id, Cart Cart)
        {
            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Cart>> postCartItem(Cart Cart)
        {

            repository.CreateCart(Cart);
            repository.Save();



            return Ok(Cart);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> deletecartItem(int id)
        {
            var itenExist = repository.getCartById(id);
            if (itenExist == null)
            {
                return NotFound();
            }

            repository.DeleteCart(id);
            repository.Save();

            return NoContent();
        }
    }
}
