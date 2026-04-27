using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.TodoItem;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("api/todoItem")]
    public class TodoItemController : ControllerBase
    {
        private readonly ITodoItemRepository _itemRepo;
        public TodoItemController(ITodoItemRepository itemRepo)
        {
            _itemRepo = itemRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var items = await _itemRepo.GetAllAsync();
            var itemDto = items.Select(i => i.ToItemDto());

            return Ok(items);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var item = await _itemRepo.GetByIdAsync(id);

            if (item == null)
            {
                return NotFound();
            }
            return Ok(item.ToItemDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateItemRequestDto itemDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var itemModel = itemDto.ToItemFromCreateDto();
            await _itemRepo.CreateAsync(itemModel);
            return CreatedAtAction(nameof(GetById), new { id = itemModel.Id }, itemModel.ToItemDto());
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateItemRequestDto updateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var itemModel = await _itemRepo.UpdateAsync(id, updateDto);

            if (itemModel == null)
            {
                return NotFound();
            }

            return Ok(itemModel.ToItemDto());
        }

        [HttpDelete]
        [Route("{id: int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var itemModel = await _itemRepo.DeleteAsync(id);
            if (itemModel == null)
            {
                return NotFound();
            }
            return NoContent();
        }

    }
}