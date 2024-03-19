using Microsoft.AspNetCore.Mvc;
using study_project.model;
using study_project.repository;

namespace study_project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository repository;

        public CustomerController(ICustomerRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public Task<ActionResult<IEnumerable<Customer>>> GetCustomerItems()
        {
            return (Task<ActionResult<IEnumerable<Customer>>>)repository.getCustomer();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetCustomerItem(int id)
        {
            var CustomerExists = repository.getCustomerById(id);

            if (CustomerExists == null)
            {
                return NotFound();
            }

            return repository.getCustomerById(id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> putCustomer(int id, Customer Customer)
        {
            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Customer>> postCustomerItem(Customer Customer)
        {

            repository.InsertCustomer(Customer);
            repository.Save();



            return Ok(Customer);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> deleteCustomerItem(int id)
        {
            var itenExist = repository.getCustomerById(id);
            if (itenExist == null)
            {
                return NotFound();
            }

            repository.DeleteCustomer(id);
            repository.Save();

            return NoContent();
        }
    }
}
