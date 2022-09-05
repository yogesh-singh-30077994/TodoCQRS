using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Todo.Domain.Command.Delete
{
    public class TodoItemDelete: IRequest<ActionResult<string>>
    {
        public readonly int id;

        public TodoItemDelete(int id)
        {
            this.id = id;
        }
    }
}
