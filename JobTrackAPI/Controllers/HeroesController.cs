using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JobTrackAPI.Models;

namespace JobTrackAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeroesController : ControllerBase
    {
        private readonly HeroesContext _context;

        public HeroesController(HeroesContext context)
        {
            _context = context;
        }

        // GET: api/Heroes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Hero>>> GetHero()
        {
            return await _context.Hero.ToListAsync();
        }

        // GET: api/Heroes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Hero>> GetHero(int id)
        {
            var hero = await _context.Hero.FindAsync(id);

            if (hero == null)
            {
                return NotFound();
            }

            return hero;
        }

        // PUT: api/Heroes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHero(int id, Hero hero)
        {
            if (id != hero.ID)
            {
                return BadRequest();
            }

            _context.Entry(hero).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HeroExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Heroes
        [HttpPost]
        public async Task<ActionResult<Hero>> PostHero(Hero hero)
        {
            _context.Hero.Add(hero);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHero", new { id = hero.ID }, hero);
        }

        // DELETE: api/Heroes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Hero>> DeleteHero(int id)
        {
            var hero = await _context.Hero.FindAsync(id);
            if (hero == null)
            {
                return NotFound();
            }

            _context.Hero.Remove(hero);
            await _context.SaveChangesAsync();

            return hero;
        }

        private bool HeroExists(int id)
        {
            return _context.Hero.Any(e => e.ID == id);
        }
    }
}
