using CaseStudy.Server.Repository;
using CaseStudy.Shared;
using Microsoft.AspNetCore.Mvc;

namespace CaseStudy.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class AbstractController<TModel> : ControllerBase where TModel : DBModel
    {
        private readonly IRepository<TModel> _repository;

        public AbstractController(IRepository<TModel> repo)
        {
            _repository = repo;
        }

        [HttpGet]
        public virtual async Task<ActionResult<IEnumerable<TModel>>> Get()
        {
            return Ok(await _repository.GetAllAsync());
        }

        [HttpGet("{id}")]
        public virtual async Task<ActionResult<TModel>> Get(long id)
        {
            var Todo = await _repository.GetAsync(id);
            if (Todo == null)
            {
                return NotFound();
            }

            return Todo;
        }

        [HttpPost]
        public virtual async Task<ActionResult<TModel>> Post(TModel Todo)
        {
            var createdTodo = await _repository.CreateAsync(Todo);
            return CreatedAtAction(nameof(Get), new { id = createdTodo.Id }, createdTodo);
        }

        [HttpPut("{id}")]
        public virtual async Task<ActionResult<TModel>> Put(long id, TModel Todo)
        {
            if (id != Todo.Id)
            {
                return BadRequest();
            }

            var updatedTodo = await _repository.UpdateAsync(Todo);
            if (updatedTodo == null)
            {
                return NotFound();
            }
            return Ok(updatedTodo);
        }

        [HttpDelete("{id}")]
        public virtual async Task<ActionResult<bool>> Delete(long id)
        {
            var result = await _repository.DeleteAsync(id);
            if (result)
            {
                return Ok();
            }

            return NotFound();
        }
    }
}
