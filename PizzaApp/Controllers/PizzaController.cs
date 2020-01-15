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

        [HttpGet("{slug}")]
        public IActionResult getPizza(string slug)
        {
            var pizza = _context.Pizza.FirstOrDefault(p => p.Slug == slug);
            if (pizza == null)
            {
                return NotFound();
            }

            return Ok(pizza);
        }

        [HttpPost]
        public IActionResult Create(Pizza newPizza)
        {
            _context.Pizza.Add(newPizza);
            _context.SaveChanges();

            return Ok(newPizza);
        }

        [HttpPut]
        public IActionResult Update(Pizza updatedPizza)
        {
            if (_context.Pizza.Count(p => p.Slug == updatedPizza.Slug) == 0)
            {
                return NotFound();
            }

            _context.Pizza.Attach(updatedPizza);
            //Nie dziala update, nie moze odwolac sie do State
            //_context.Entry(updatedPizza).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();

            return Ok(updatedPizza);
        }

        [HttpDelete("{idPizza:Guid}")]
        public IActionResult Delete(Guid idPizza)
        {
            var p = _context.Pizza.FirstOrDefault(t => t.IdPizza == idPizza);
            if (p == null)
            {
                return NotFound();
            }

            _context.Pizza.Remove(p);
            _context.SaveChanges();

            return Ok(p);
        }

    }
}