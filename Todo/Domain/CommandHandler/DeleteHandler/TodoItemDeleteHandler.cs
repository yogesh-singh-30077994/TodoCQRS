using MediatR;
using Todo.Data.Interface;
using Todo.Domain.Command.Delete;

namespace Todo.Domain.CommandHandler.DeleteHandler
{
    public class TodoItemDeleteHandler : IRequestHandler<TodoItemDelete, string>
    {
        private readonly ITodoDB _todoDB;

        public TodoItemDeleteHandler(ITodoDB todoDB)
        {
            _todoDB = todoDB;
        }

        public async Task<string> Handle(TodoItemDelete request, CancellationToken cancellationToken)
        {
            return await _todoDB.DeleteTodoItem(request.id);
        }
    }
}
