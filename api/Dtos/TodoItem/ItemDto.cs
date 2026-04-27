using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos
{
    public class ItemDto
    {
        public int Id {get; set;}
        public string Name {get; set;} = string.Empty; 
        public bool IsCompleted {get; set;} 
        public int TodoListId {get; set;}

    }
}