using MediatR;
using Microsoft.AspNetCore.Mvc;
using Todo.Models;

namespace Todo.Domain.Command.Create
{
    public class TodoItemCreate:IRequest<ActionResult<TodoItem>>
    {
        public readonly TodoItem todoItem;

        public TodoItemCreate(TodoItem todoItem)
        {
            this.todoItem = todoItem;
        }
    }
}
