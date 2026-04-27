using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.TodoItem
{
    public class CreateItemRequestDto
    {
        [Required]
        public string Name { get; set; } = string.Empty;
        public int TodoListId { get; set; }

    }
}