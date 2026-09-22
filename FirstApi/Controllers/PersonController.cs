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
        public PersonController()
        {
            this.service = new PersonService();
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Person>>> GetUsers()
        {
            return Ok(await service.GetAllAsync());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Person>> GetUserById(string id)
        {
            return Ok(await service.GetById(id));
        }
        [HttpPost]
        public async Task<ActionResult<Person>> PostUser([FromBody]Person person)
        {
            if (service.Create(person))
                return CreatedAtAction(nameof(GetUserById),
                    new { Id = person.Id }, person);
            return BadRequest();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Person>> DeleteUser(string id)
        {
            if (service.Delete(id))
                return NoContent();
            return NotFound();
        }
        [HttpPut]
        public async Task<ActionResult<Person>> UpdateUser([FromBody] Person person)
        {
            if (service.Update(person))
                return Ok(person);
            return NotFound();
        }
    }
}
