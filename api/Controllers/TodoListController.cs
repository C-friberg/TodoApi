using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("api/todoList")]
    public class TodoListController : ControllerBase
    {
        private readonly AppDbContext _context; 
        
    }
}