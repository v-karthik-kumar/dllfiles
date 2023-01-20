using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using aws_test.Models;
using aws_test.Interfaces;

namespace aws_test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoModelsController : ControllerBase
    {
        ITodoService _todoService;

        public TodoModelsController(ITodoService service)
        {
            _todoService = service;
        }

        // GET: api/TodoModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TodoList>>> GetTodoItems()
        {
            try
            {
                var todos = _todoService.GetTodoList();
                if (todos == null) return NotFound();
                return Ok(todos);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // GET: api/TodoModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TodoList>> GetTodoModel(Guid id)
        {
            try
            {
                var todo = _todoService.GetTodoDetailsById(id);
                if (todo == null) return NotFound();
                return Ok(todo);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // PUT: api/TodoModels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTodoModel(Guid id, TodoList todoModel)
        {
            return NoContent();
        }

        // POST: api/TodoModels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TodoList>> PostTodoModel(TodoList todoModel)
        {
            try
            {
                var model = _todoService.SaveTodoItem(todoModel);
                return Ok(model);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // DELETE: api/TodoModels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodoModel(Guid id)
        {
            try
            {
                var model = _todoService.DeleteTodo(id);
                return Ok(model);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
