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
    public class SkladnikController : ControllerBase
    {
        private s16682Context _context;
        public SkladnikController(s16682Context context)
        {
            _context = context;
        }


        /// <summary>
        /// Metoda zwraca dane dotyczace składnikow
        /// </summary>
        /// <returns>Lista obeitktów reprezentujacych skladnik</returns>

        [HttpGet]
        public IActionResult getSladniks()
        {
            return Ok(_context.Skladnik.ToList());
        }

        [HttpGet("{id:int}")]
        public IActionResult getSkladnik(int id)
        {
            var skladnik = _context.Skladnik.FirstOrDefault(s => s.IdSkladnik == id);

            if (skladnik == null)
            {
                return NotFound();
            }

            return Ok(skladnik);
        }
    }
}