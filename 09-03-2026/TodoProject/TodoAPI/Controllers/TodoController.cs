using Microsoft.AspNetCore.Mvc;
using TodoAPI.Data;
using TodoAPI.Models;

namespace TodoAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodoController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TodoController(ApplicationDbContext context)
        {
            _context = context;
        }

        

        // GET: api/todo
        [HttpGet]
        public IActionResult GetTodos()
        {
            var todos = _context.Todos.ToList();
            return Ok(todos);
        }

        // POST: api/todo
        [HttpPost]
        public IActionResult AddTodo(TodoItem todo)
        {
            _context.Todos.Add(todo);
            _context.SaveChanges();

            return Ok(todo);
        }

        // DELETE: api/todo/5
        [HttpDelete("{id}")]
        public IActionResult DeleteTodo(int id)
        {
            var todo = _context.Todos.Find(id);

            if (todo == null)
            {
                return NotFound();
            }

            _context.Todos.Remove(todo);
            _context.SaveChanges();

            return Ok();
        }

       [HttpPut("{id}")]
        public IActionResult UpdateTodo(int id, TodoItem updated)
        {
            var todo = _context.Todos.Find(id);

            if (todo == null)
                return NotFound();

            todo.Task = updated.Task;
            todo.IsCompleted = updated.IsCompleted;

            _context.SaveChanges();

            return Ok(todo);
        }
        
    }
}