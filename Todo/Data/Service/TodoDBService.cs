using Microsoft.EntityFrameworkCore;
using Todo.Data.Interface;
using Todo.Models;

namespace Todo.Data.Service
{
    public class TodoDBService : ITodoDB
    {
        private readonly TodoContext _context;

        public TodoDBService(TodoContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TodoItem>> GetTodoItems()
        {
            if (_context.TodoItem == null)
            {
                throw new Exception("Entity set 'TodoContext.TodoItem'  is null.");
            }
            return await _context.TodoItem.ToListAsync();
        }

        public async Task<TodoItem> GetTodoItem(int id)
        {
            if (_context.TodoItem == null)
            {
                throw new Exception("Entity set 'TodoContext.TodoItem'  is null.");
            }
            var todoItem = await _context.TodoItem.FindAsync(id);
            if (todoItem == null)
            {
                throw new Exception("No TodoItem for given ID");
            }
            return todoItem;
        }

        public async Task<TodoItem> CreateTodoItem(TodoItem todoItem)
        {
            if (_context.TodoItem == null)
            {
                throw new Exception("Entity set 'TodoContext.TodoItem'  is null.");
            }
            _context.TodoItem.Add(todoItem);
            await _context.SaveChangesAsync();

            return todoItem;
        }

        public async Task<string> UpdateTodoItem(int id, TodoItem todoItem)
        {
            if (id != todoItem.Id)
            {
                throw new Exception("Bad Request");
            }

            _context.Entry(todoItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TodoItemExists(id))
                {
                    throw new Exception("TodoItem Does Not exists!");
                }
                else
                {
                    throw;
                }
            }

            return string.Empty;
        }

        public async Task<string> DeleteTodoItem(int id)
        {
            if (_context.TodoItem == null)
            {
                throw new Exception("Entity set 'TodoContext.TodoItem'  is null.");
            }
            var todoItem = await _context.TodoItem.FindAsync(id);
            if (todoItem == null)
            {
                throw new Exception("TodoItem does not exists.");
            }

            _context.TodoItem.Remove(todoItem);
            await _context.SaveChangesAsync();

            return string.Empty;
        }

        private bool TodoItemExists(int id)
        {
            return (_context.TodoItem?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
