using MediatR;
using Todo.Models;

namespace Todo.Domain.Query
{
    public class GetTodoItemQuery: IRequest<TodoItem>
    {
        public readonly int todoItemId;

        public GetTodoItemQuery(int todoItemId)
        {
            this.todoItemId = todoItemId;
        }
    }
}
