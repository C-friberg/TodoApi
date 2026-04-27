using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.TodoItem;
using api.Models;

namespace api.Interfaces
{
    public interface ITodoItemRepository
    {
        Task<List<TodoItem>> GetAllAsync();
        Task<TodoItem?> GetByIdAsync(int id);
        Task<TodoItem> CreateAsync(TodoItem itemModel);
        Task<TodoItem?> UpdateAsync(int id, UpdateItemRequestDto itemModel);
        Task<TodoItem?> DeleteAsync(int id);
    }
}