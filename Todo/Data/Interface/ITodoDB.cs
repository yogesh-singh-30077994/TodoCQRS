using Todo.Models;

namespace Todo.Data.Interface
{
    public interface ITodoDB
    {
        Task<IEnumerable<TodoItem>> GetTodoItems();
        Task<TodoItem> GetTodoItem(int id);
        Task<TodoItem> CreateTodoItem(TodoItem todoItem);
        Task<string> UpdateTodoItem(int id, TodoItem todoItem);
        Task<string> DeleteTodoItem(int id);
    }
}
