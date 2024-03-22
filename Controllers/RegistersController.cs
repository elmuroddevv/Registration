using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Registration.Models;
using Registration.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Registration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class RegistersController : ControllerBase
    {
        private readonly IGenericService<RegisterModel> _registerSvc;
        public RegistersController(IGenericService<RegisterModel> registerSvc)
        {
            _registerSvc = registerSvc;
        }
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Get()
        {
            return Ok(await _registerSvc.GetAll());
        }
        // GET api/<RegistersController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                return await Task.FromResult(Ok(_registerSvc.Get(id)));
            }catch (Exception ex)
            {
                return NotFound($"User just NotFound");
            }
            
        }

        // POST api/<RegistersController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] RegisterModel register)
        {
            var createdRegister = await _registerSvc.Create(register);
            var routeValues = new { id = createdRegister.Id };
            return CreatedAtRoute(routeValues, createdRegister);
        }

        // PUT api/<RegistersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<RegistersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
