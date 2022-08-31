using Microsoft.AspNetCore.Mvc;
using Todo.Models;

namespace Todo.Interfaces
{
    public interface ITodo
    {
        Task<IEnumerable<TodoItem>> GetTodoItems();

        Task<TodoItem> GetTodoItem(int id);

        Task<TodoItem> PostTodoItem(TodoItem todoItem);

        Task<string> PutTodoItem(int id, TodoItem todoItem);

        Task<string> DeleteTodoItem(int id);
    }
}
