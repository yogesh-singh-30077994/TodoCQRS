using Microsoft.AspNetCore.Mvc;
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

        public async Task<ActionResult<IEnumerable<TodoItem>>> GetTodoItems()
        {
            if (_context.TodoItem == null)
            {
                return new NotFoundResult();
            }
            return await _context.TodoItem.ToListAsync();
        }

        public async Task<ActionResult<TodoItem>> GetTodoItem(int id)
        {
            if (_context.TodoItem == null)
            {
                return new NotFoundResult();
            }
            var todoItem = await _context.TodoItem.FindAsync(id);
            if (todoItem == null)
            {
                return new NotFoundResult();
            }
            return todoItem;
        }

        public async Task<ActionResult<TodoItem>> CreateTodoItem(TodoItem todoItem)
        {
            if (_context.TodoItem == null)
            {
                return new NotFoundResult();
            }
            _context.TodoItem.Add(todoItem);
            await _context.SaveChangesAsync();

            return todoItem;
        }

        public async Task<ActionResult<string>> UpdateTodoItem(int id, TodoItem todoItem)
        {
            if (id != todoItem.Id)
            {
                return new BadRequestResult();
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
                    return new NotFoundResult();
                }
                else
                {
                    throw;
                }
            }

            return string.Empty;
        }

        public async Task<ActionResult<string>> DeleteTodoItem(int id)
        {
            if (_context.TodoItem == null)
            {
                return new NotFoundResult();
            }
            var todoItem = await _context.TodoItem.FindAsync(id);
            if (todoItem == null)
            {
                return new NotFoundResult();
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
