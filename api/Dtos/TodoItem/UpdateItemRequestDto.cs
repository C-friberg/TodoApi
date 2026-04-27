using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.TodoItem
{
    public class UpdateItemRequestDto
    {
        [Required]
        public string Name { get; set; } = string.Empty;
        public bool IsCompleted { get; set; }
        [Range(1, int.MaxValue)]
        public int TodoListId { get; set; }

    }
}