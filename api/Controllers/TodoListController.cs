using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.TodoList;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [ApiController]
    [Route("api/todoList")]
    public class TodoListController : ControllerBase
    {
        private readonly ITodoListRepository _listRepo;
        public TodoListController(ITodoListRepository listRepo)
        {
            _listRepo = listRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var lists = await _listRepo.GetAllAsync();
            var listDto = lists.Select(l => l.ToListDto());

            return Ok(listDto);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var list = await _listRepo.GetByIdAsync(id);
            if (list == null)
            {
                return NotFound();
            }
            return Ok(list.ToListDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateListRequestDto listDto)
        {
            Console.WriteLine("CREATE TODOLIST HIT");
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var listModel = listDto.ToListFromCreateDto();
            await _listRepo.CreateAsync(listModel);
            return Ok(/* nameof(GetById), new { id = listModel.Id },  */listModel.ToListDto());
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateListRequestDto updateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var list = await _listRepo.UpdateAsync(id, updateDto.ToListFromUpdate());
            if (list == null)
            {
                return NotFound();
            }
            return Ok(list.ToListDto());
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var listModel = await _listRepo.DeleteAsync(id);
            if (listModel == null)
            {
                return NotFound();
            }
            return NoContent();
        }

    }
}