using CaseStudy.Server.Repository;
using CaseStudy.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CaseStudy.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly IRepository<Todo> _todoRepository;

        public TodoController(IRepository<Todo> todoRepository)
        {
            _todoRepository = todoRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Todo>>> Get()
        {
            return Ok(await _todoRepository.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Todo>> Get(long id)
        {
            var Todo = await _todoRepository.GetAsync(id);
            if (Todo == null)
            {
                return NotFound();
            }

            return Todo;
        }

        [HttpPost]
        public async Task<ActionResult<Todo>> Post(Todo Todo)
        {
            var createdTodo = await _todoRepository.CreateAsync(Todo);
            return CreatedAtAction(nameof(Get), new { id = createdTodo.Id }, createdTodo);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Todo>> Put(long id, Todo Todo)
        {
            if (id != Todo.Id)
            {
                return BadRequest();
            }

            var updatedTodo = await _todoRepository.UpdateAsync(Todo);
            if (updatedTodo == null)
            {
                return NotFound();
            }
            return Ok(updatedTodo);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(long id)
        {
            var result = await _todoRepository.DeleteAsync(id);
            if (result)
            {
                return Ok();
            }

            return NotFound();
        }
    }
}
