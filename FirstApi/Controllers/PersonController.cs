using FirstApi.Models;
using FirstApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace FirstApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController:ControllerBase
    {
        private readonly PersonService service;
        public PersonController(PersonService _service)
        {
            this.service= _service;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Person>>> GetUsers()
        {
            return Ok(await service.GetAllAsync());
        }

    }
}
