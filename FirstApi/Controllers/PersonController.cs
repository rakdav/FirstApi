using FirstApi.Models;
using FirstApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace FirstApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly PersonService service;
        public PersonController(PersonService _service)
        {
            this.service = _service;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Person>>> GetUsers()
        {
            return Ok(await service.GetAllAsync());
        }
        [HttpGet]
        public async Task<ActionResult<Person>> GetUserById(string id)
        {
            return Ok(await service.GetById(id));
        }
        [HttpPost]
        public async Task<ActionResult<Person>> PostUser(Person person)
        {
            await service.Create(person);

        }
    }
}
