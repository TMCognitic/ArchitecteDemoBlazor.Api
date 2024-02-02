using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly ITodoRepository _repository;

        public TodoController(ITodoRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_repository.Get());
        }

        [HttpPost]
        public IActionResult Post([FromBody] CreateTodoForm Form)
        {
            Todo todo = _repository.Add(Form.Title);

            return Ok(todo);
        }

        [HttpPatch("cloture/{id}")]
        [HttpPut("cloture/{id}")]
        public IActionResult Cloture(int id)
        {
            if (_repository.Cloture(id))
                return NoContent();
            else
                return NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (_repository.Delete(id))
                return NoContent();
            else
                return NotFound();
        }
    }
}
