using MediatR;
using Todo.Models;

namespace Todo.Domain.Query
{
    public class GetTodoItemsQuery:IRequest<IEnumerable<TodoItem>>
    {
    }
}
