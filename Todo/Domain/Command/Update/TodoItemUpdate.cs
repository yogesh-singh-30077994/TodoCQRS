using MediatR;
using Microsoft.AspNetCore.Mvc;
using Todo.Models;

namespace Todo.Domain.Command.Update
{
    public class TodoItemUpdate: IRequest<ActionResult<string>>
    {
        public readonly int id;
        public readonly TodoItem todoItem;

        public TodoItemUpdate(int id, TodoItem todoItem)
        {
            this.id = id;
            this.todoItem = todoItem;
        }
    }
}
