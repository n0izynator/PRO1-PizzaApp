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
    public class typController : ControllerBase
    {
        private s16682Context _context;
        public typController(s16682Context context)
        {
            _context = context;
        }


        [HttpGet]
        public IActionResult getTyps()
        {
            return Ok(_context.Typ.ToList());
        }

        [HttpGet("{id:int}")]
        public IActionResult getTyp(int id)
        {
            var typ = _context.Typ.FirstOrDefault(s => s.IdTyp == id);

            if (typ == null)
            {
                return NotFound();
            }

            return Ok(typ);
        }

        [HttpPost]
        public IActionResult Create(Typ newTyp)
        {
            _context.Typ.Add(newTyp);
            _context.SaveChanges();

            return StatusCode(201, newTyp);
        }

        [HttpPut]
        public IActionResult Update(Typ updatedTyp)
        {

            if(_context.Typ.Count(typ => typ.IdTyp == updatedTyp.IdTyp) == 0)
            {
                return NotFound();
            }

            _context.Typ.Attach(updatedTyp);
            _context.Entry(updatedTyp).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();

            return Ok(updatedTyp);
        }

        [HttpDelete("{idTyp:int}")]
        public IActionResult Delete(int idTyp)
        {
            var typ = _context.Typ.FirstOrDefault(t => t.IdTyp == idTyp);
            if(typ == null)
            {
                return NotFound();
            }

            _context.Typ.Remove(typ);
            _context.SaveChanges();

            return Ok(typ);
        }

    }
}