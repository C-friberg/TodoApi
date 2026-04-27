using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos;
using api.Dtos.TodoItem;
using api.Models;

namespace api.Mappers
{
    public static class ItemMappers
    {
        public static ItemDto ToItemDto(this TodoItem itemModel)
        {
            return new ItemDto
            {
                Id = itemModel.Id,
                Name = itemModel.Name,
                IsCompleted = itemModel.IsCompleted,
                TodoListId = itemModel.TodoListId
            };
        }

        public static TodoItem ToItemFromCreateDto(this CreateItemRequestDto itemDto)
        {
            return new TodoItem
            {
                Name = itemDto.Name,
                TodoListId = itemDto.TodoListId,
                IsCompleted = false
            };
        }

        public static TodoItem ToItemFromUpdate(this UpdateItemRequestDto itemDto)
        {
            return new TodoItem
            {
                Name = itemDto.Name,
                TodoListId = itemDto.TodoListId
            };
        }
    }
}