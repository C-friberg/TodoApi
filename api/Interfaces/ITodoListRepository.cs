using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;

namespace api.Interfaces
{
    public interface ITodoListRepository
    {
        Task<List<TodoList>> GetAllAsync(); 
        Task<TodoList?> GetByIdAsync(int id); 
        Task<TodoList> CreateAsync(TodoList listModel); 
        Task<TodoList?> UpdateAsync(int id, TodoList listModel); 
        Task<TodoList?> DeleteAsync(int id); 
    }
}