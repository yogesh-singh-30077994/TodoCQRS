﻿using MediatR;
using Todo.Data;
using Todo.Data.Interface;
using Todo.Domain.Query;
using Todo.Models;

namespace Todo.Domain.QueryHandler
{
    public class GetTodoItemQueryHandler : IRequestHandler<GetTodoItemQuery, TodoItem>
    {
        private readonly ITodoDB _todoDB;

        public GetTodoItemQueryHandler(TodoContext context, ITodoDB todoDB)
        {
            _todoDB = todoDB;
        }

        public async Task<TodoItem> Handle(GetTodoItemQuery request, CancellationToken cancellationToken)
        {
            return await _todoDB.GetTodoItem(request.todoItemId);
        }
    }
}
