using Microsoft.AspNetCore.Mvc;
using Todo.Interfaces;
using Todo.Models;

namespace Todo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly ITodo _todo;

        public TodoController(ITodo todo)
        {
            _todo = todo;
        }

        [HttpGet]
        public Task<ActionResult<IEnumerable<TodoItem>>> GetTodoItems()
        {
            return _todo.GetTodoItems();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TodoItem>> GetTodoItem(int id)
        {
            return await _todo.GetTodoItem(id);
        }

        [HttpPost]
        public async Task<ActionResult<TodoItem>> PostTodoItem(TodoItem todoItem)
        {
            return await _todo.PostTodoItem(todoItem);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<string>> PutTodoItem(int id, TodoItem todoItem)
        {
            return await _todo.PutTodoItem(id, todoItem);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<string>> DeleteTodoItem(int id)
        {
            return await _todo.DeleteTodoItem(id);
        }
    }
}
