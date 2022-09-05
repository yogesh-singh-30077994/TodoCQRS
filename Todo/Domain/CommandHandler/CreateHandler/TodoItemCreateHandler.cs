using MediatR;
using Microsoft.AspNetCore.Mvc;
using Todo.Data.Interface;
using Todo.Domain.Command.Create;
using Todo.Models;

namespace Todo.Domain.CommandHandler.CreateHandler
{
    public class TodoItemCreateHandler : IRequestHandler<TodoItemCreate, ActionResult<TodoItem>>
    {
        private readonly ITodoDB _todoDB;

        public TodoItemCreateHandler(ITodoDB todoDB)
        {
            _todoDB = todoDB;
        }

        public async Task<ActionResult<TodoItem>> Handle(TodoItemCreate request, CancellationToken cancellationToken)
        {
            return await _todoDB.CreateTodoItem(request.todoItem);
        }
    }
}
