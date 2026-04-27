using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class TodoListRepository : ITodoListRepository
    {
        private readonly AppDbContext _context;
        public TodoListRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<TodoList> CreateAsync(TodoList listModel)
        {
            await _context.TodoLists.AddAsync(listModel);
            await _context.SaveChangesAsync();
            return listModel;
        }

        public async Task<TodoList?> DeleteAsync(int id)
        {
            var listModel = await _context.TodoLists.FirstOrDefaultAsync(x => x.Id == id);
            if (listModel == null)
            {
                return null;
            }
            _context.TodoLists.Remove(listModel);
            await _context.SaveChangesAsync();

            return listModel;
        }

        public async Task<List<TodoList>> GetAllAsync()
        {
            return await _context.TodoLists.ToListAsync();
        }

        public async Task<TodoList?> GetByIdAsync(int id)
        {
            return await _context.TodoLists.FindAsync(id);
        }

        public async Task<TodoList?> UpdateAsync(int id, TodoList listModel)
        {
            var existingList = await _context.TodoLists.FindAsync(id);

            if (existingList == null)
            {
                return null;
            }

            existingList.Name = listModel.Name;

            await _context.SaveChangesAsync();
            return existingList;
        }
    }
}