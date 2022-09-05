using MediatR;
using Microsoft.AspNetCore.Mvc;
using Todo.Data.Interface;
using Todo.Domain.Command.Delete;

namespace Todo.Domain.CommandHandler.DeleteHandler
{
    public class TodoItemDeleteHandler : IRequestHandler<TodoItemDelete, ActionResult<string>>
    {
        private readonly ITodoDB _todoDB;

        public TodoItemDeleteHandler(ITodoDB todoDB)
        {
            _todoDB = todoDB;
        }

        public async Task<ActionResult<string>> Handle(TodoItemDelete request, CancellationToken cancellationToken)
        {
            return await _todoDB.DeleteTodoItem(request.id);
        }
    }
}
