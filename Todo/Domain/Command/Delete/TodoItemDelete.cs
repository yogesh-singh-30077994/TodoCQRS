using MediatR;

namespace Todo.Domain.Command.Delete
{
    public class TodoItemDelete: IRequest<string>
    {
        public readonly int id;

        public TodoItemDelete(int id)
        {
            this.id = id;
        }
    }
}
