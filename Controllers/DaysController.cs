using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Adutova_TKR2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Adutova_TKR2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DaysController : ControllerBase
    {
        private readonly TodoContext _context;

        public DaysController(TodoContext context)
        {
            _context = context;
        }

        // GET: api/Days
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Day>>> GetDays()
        {
            return await _context.Days.ToListAsync();
        }

        // GET: api/Days/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Day>> GetDay(long id)
        {
            var Day = await _context.Days.FindAsync(id);

            if (Day == null)
            {
                return NotFound();
            }

            return Day;
        }

        // PUT: api/Days/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDay(long id, Day Day)
        {
            if (id != Day.Id)
            {
                return BadRequest();
            }

            _context.Entry(Day).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DayExists(id))
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

        // POST: api/Days
        [HttpPost]
        public async Task<ActionResult<Day>> PostDay([FromForm]Day Day)
        {
            _context.Days.Add(Day);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDay", new { id = Day.Id }, Day);
        }

        // DELETE: api/Days/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Day>> DeleteDay(long id)
        {
            var Day = await _context.Days.FindAsync(id);
            if (Day == null)
            {
                return NotFound();
            }

            _context.Days.Remove(Day);
            await _context.SaveChangesAsync();

            return Day;
        }

        private bool DayExists(long id)
        {
            return _context.Days.Any(e => e.Id == id);
        }
    }
}
