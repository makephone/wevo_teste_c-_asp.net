using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestWithASPNETUdemy.Model;
using RestWithASPNETUdemy.Services;

namespace RestWithASPNETUdemy.Controllers
{
    [ApiController]
    [Route("api_rest/[controller]")]
    public class PersonController : ControllerBase
    {

        private readonly ILogger<PersonController> _logger;

        // Declaração da variavel de serviço
        private IPersonService _personService;

        // Injetando a instancia de pessoa
        //creando a instancia da pagina controladora
        public PersonController(ILogger<PersonController> logger, IPersonService personService)
        {
            _logger = logger;
            _personService = personService;
        }

        // GET    https://localhost:{port}/api_rest/person
       
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_personService.FindAll());
        }

        // GET requests to https://localhost:{port}/api_rest/person/{id}
        
        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var person = _personService.FindByID(id);
            if (person == null) return NotFound();
            return Ok(person);
        }

        // POST  https://localhost:{port}/api_rest/person/
      
        [HttpPost]
        public IActionResult Post([FromBody] Cliente person)
        {
            if (person == null) return BadRequest();
            return Ok(_personService.Create(person));
        }

        //PUT  https://localhost:{port}/api_rest/person/
   
        [HttpPut]
        public IActionResult Put([FromBody] Cliente person)
        {
            if (person == null) return BadRequest();
            return Ok(_personService.Update(person));
        }

        // DELETE https://localhost:{port}/api_rest/person/{id}

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            _personService.Delete(id);
            return NoContent();
        }
    }
}
