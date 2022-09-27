using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Chemicals___Sri_Arungarai_Amman_Traders.Models;

namespace Chemicals___Sri_Arungarai_Amman_Traders.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChemicalsController : ControllerBase
    {
        private readonly Sri_Arungarai_Amman_TradersContext _context;

        public ChemicalsController(Sri_Arungarai_Amman_TradersContext context)
        {
            _context = context;
        }

        // GET: api/Chemicals
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Chemical>>> GetChemicals()
        {
            return await _context.Chemicals.ToListAsync();
        }

        // GET: api/Chemicals/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Chemical>> GetChemical(int id)
        {
            var chemical = await _context.Chemicals.FindAsync(id);

            if (chemical == null)
            {
                return NotFound();
            }

            return chemical;
        }

        // PUT: api/Chemicals/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutChemical(int id, Chemical chemical)
        {
            if (id != chemical.ProductId)
            {
                return BadRequest();
            }

            _context.Entry(chemical).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChemicalExists(id))
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

        // POST: api/Chemicals
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Chemical>> PostChemical(Chemical chemical)
        {
            _context.Chemicals.Add(chemical);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetChemical", new { id = chemical.ProductId }, chemical);
        }

        // DELETE: api/Chemicals/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteChemical(int id)
        {
            var chemical = await _context.Chemicals.FindAsync(id);
            if (chemical == null)
            {
                return NotFound();
            }

            _context.Chemicals.Remove(chemical);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ChemicalExists(int id)
        {
            return _context.Chemicals.Any(e => e.ProductId == id);
        }
    }
}
