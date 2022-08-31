using MediatR;
using Todo.Domain.Command.Create;
using Todo.Domain.Command.Delete;
using Todo.Domain.Command.Update;
using Todo.Domain.Query;
using Todo.Interfaces;
using Todo.Models;

namespace Todo.Services
{
    public class TodoService : ITodo
    {
        private readonly IMediator _mediatr;

        public TodoService(IMediator mediator)
        {
            _mediatr = mediator;
        }

        public async Task<IEnumerable<TodoItem>> GetTodoItems()
        {
            return await _mediatr.Send(new GetTodoItemsQuery());
        }

        public async Task<TodoItem> GetTodoItem(int id)
        {
            return await _mediatr.Send(new GetTodoItemQuery(id));
        }

        public async Task<TodoItem> PostTodoItem(TodoItem todoItem)
        {
            return await _mediatr.Send(new TodoItemCreate(todoItem));
        }

        public async Task<string> PutTodoItem(int id, TodoItem todoItem)
        {
            return await _mediatr.Send(new TodoItemUpdate(id, todoItem));
        }

        public async Task<string> DeleteTodoItem(int id)
        {
            return await _mediatr.Send(new TodoItemDelete(id));
        }
    }
}
