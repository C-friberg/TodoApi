using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.TodoList;
using api.Models;

namespace api.Mappers
{
    public static class ListMappers
    {
        public static ListDto ToListDto(this TodoList listModel)
        {
            return new ListDto
            {
                Id = listModel.Id,
                Name = listModel.Name
            };
        }

        public static TodoList ToListFromCreateDto(this CreateListRequestDto listDto)
        {
            return new TodoList
            {
                Name = listDto.Name
            };
        }

        public static TodoList ToListFromUpdate(this UpdateListRequestDto listDto)
        {
            return new TodoList
            {
                Name = listDto.Name
            };
        }
    }
}