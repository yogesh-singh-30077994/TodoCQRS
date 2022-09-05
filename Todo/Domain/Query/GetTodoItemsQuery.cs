using MediatR;
using Microsoft.AspNetCore.Mvc;
using Todo.Models;

namespace Todo.Domain.Query
{
    public class GetTodoItemsQuery:IRequest<ActionResult<IEnumerable<TodoItem>>>
    {
    }
}
