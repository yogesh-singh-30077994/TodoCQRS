using MediatR;
using Todo.Models;

namespace Todo.Domain.Command.Create
{
    public class TodoItemCreate:IRequest<TodoItem>
    {
        public readonly TodoItem todoItem;

        public TodoItemCreate(TodoItem todoItem)
        {
            this.todoItem = todoItem;
        }
    }
}
