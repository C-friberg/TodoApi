using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.TodoList
{
    public class UpdateListRequestDto
    {
        public string Name { get; set; } = string.Empty;
    }
}