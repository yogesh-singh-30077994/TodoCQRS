using Microsoft.AspNetCore.Mvc;
using Todo.Models;

namespace Todo.Data.Interface
{
    public interface ITodoDB
    {
        Task<ActionResult<IEnumerable<TodoItem>>> GetTodoItems();
        Task<ActionResult<TodoItem>> GetTodoItem(int id);
        Task<ActionResult<TodoItem>> CreateTodoItem(TodoItem todoItem);
        Task<ActionResult<string>> UpdateTodoItem(int id, TodoItem todoItem);
        Task<ActionResult<string>> DeleteTodoItem(int id);
    }
}
