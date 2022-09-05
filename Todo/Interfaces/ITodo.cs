using Microsoft.AspNetCore.Mvc;
using Todo.Models;

namespace Todo.Interfaces
{
    public interface ITodo
    {
        Task<ActionResult<IEnumerable<TodoItem>>> GetTodoItems();

        Task<ActionResult<TodoItem>> GetTodoItem(int id);

        Task<ActionResult<TodoItem>> PostTodoItem(TodoItem todoItem);

        Task<ActionResult<string>> PutTodoItem(int id, TodoItem todoItem);

        Task<ActionResult<string>> DeleteTodoItem(int id);
    }
}
