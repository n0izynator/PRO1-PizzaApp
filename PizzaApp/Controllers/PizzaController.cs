using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaApp.Models;

namespace PizzaApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzaController : ControllerBase
    {
        private s16682Context _context;
        public PizzaController(s16682Context context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult getPizzas()
        {
            return Ok(_context.Pizza.ToList());
        }
    }
}