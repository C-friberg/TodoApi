using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class TodoItem
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        //FK
        public int TodoListId { get; set; }
        public TodoList? TodoList { get; set; }
    }
}