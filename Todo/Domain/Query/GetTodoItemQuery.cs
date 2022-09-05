using MediatR;
using Microsoft.AspNetCore.Mvc;
using Todo.Models;

namespace Todo.Domain.Query
{
    public class GetTodoItemQuery: IRequest<ActionResult<TodoItem>>
    {
        public readonly int todoItemId;

        public GetTodoItemQuery(int todoItemId)
        {
            this.todoItemId = todoItemId;
        }
    }
}
