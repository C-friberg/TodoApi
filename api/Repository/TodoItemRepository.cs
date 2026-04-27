using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.TodoItem;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class TodoItemRepository : ITodoItemRepository
    {
        private readonly AppDbContext _context;
        public TodoItemRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<TodoItem> CreateAsync(TodoItem itemModel)
        {
            await _context.TodoItems.AddAsync(itemModel);
            await _context.SaveChangesAsync();
            return itemModel;
        }

        public async Task<TodoItem?> DeleteAsync(int id)
        {
            var itemModel = await _context.TodoItems.FirstOrDefaultAsync(x => x.Id == id);
            if (itemModel == null)
            {
                return null;
            }
            _context.TodoItems.Remove(itemModel);
            await _context.SaveChangesAsync();

            return itemModel;
        }

        public async Task<List<TodoItem>> GetAllAsync()
        {
            return await _context.TodoItems.ToListAsync();
        }

        public async Task<TodoItem?> GetByIdAsync(int id)
        {
            return await _context.TodoItems.FindAsync(id);
        }

        public async Task<TodoItem?> UpdateAsync(int id, UpdateItemRequestDto itemModel)
        {
            var existingItem = await _context.TodoItems.FindAsync(id);

            if (existingItem == null)
            {
                return null;
            }

            existingItem.Name = itemModel.Name;
            existingItem.IsCompleted = itemModel.IsCompleted;
            existingItem.TodoListId = itemModel.TodoListId;

            await _context.SaveChangesAsync();
            return existingItem;
        }
    }
}