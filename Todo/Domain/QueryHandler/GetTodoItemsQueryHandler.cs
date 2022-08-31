using MediatR;
using Todo.Data.Interface;
using Todo.Domain.Query;
using Todo.Models;

namespace Todo.Domain.QueryHandler
{
    public class GetTodoItemsQueryHandler : IRequestHandler<GetTodoItemsQuery, IEnumerable<TodoItem>>
    {
        private readonly ITodoDB _todoDB;

        public GetTodoItemsQueryHandler(ITodoDB todoDB)
        {
            _todoDB = todoDB;
        }

        public async Task<IEnumerable<TodoItem>> Handle(GetTodoItemsQuery request, CancellationToken cancellationToken)
        {
            return await _todoDB.GetTodoItems();
        }
    }
}
