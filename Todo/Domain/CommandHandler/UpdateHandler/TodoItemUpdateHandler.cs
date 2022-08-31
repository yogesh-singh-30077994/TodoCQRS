﻿using MediatR;
using Todo.Data.Interface;
using Todo.Domain.Command.Update;

namespace Todo.Domain.CommandHandler.UpdateHandler
{
    public class TodoItemUpdateHandler : IRequestHandler<TodoItemUpdate, string>
    {
        private readonly ITodoDB _todoDB;

        public TodoItemUpdateHandler(ITodoDB todoDB)
        {
            _todoDB = todoDB;
        }

        public async Task<string> Handle(TodoItemUpdate request, CancellationToken cancellationToken)
        {
            return await _todoDB.UpdateTodoItem(request.id, request.todoItem);
        }
    }
}
