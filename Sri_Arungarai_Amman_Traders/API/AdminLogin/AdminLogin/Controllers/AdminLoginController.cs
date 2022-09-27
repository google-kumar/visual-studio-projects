using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AdminLogin___Sri_Arungarai_Amman_Traders.Models;

namespace AdminLogin___Sri_Arungarai_Amman_Traders.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminLoginController : ControllerBase
    {
        private readonly Sri_Arungarai_Amman_TradersContext _context;

        public AdminLoginController(Sri_Arungarai_Amman_TradersContext context)
        {
            _context = context;
        }

        // GET: api/AdminLogin
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AdminLogin>>> GetAdminLogins()
        {
            return await _context.AdminLogins.ToListAsync();
        }

        // GET: api/AdminLogin/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AdminLogin>> GetAdminLogin(string id)
        {
            var adminLogin = await _context.AdminLogins.FindAsync(id);

            if (adminLogin == null)
            {
                return NotFound();
            }

            return adminLogin;
        }

        // PUT: api/AdminLogin/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAdminLogin(string id, AdminLogin adminLogin)
        {
            if (id != adminLogin.UserName)
            {
                return BadRequest();
            }

            _context.Entry(adminLogin).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdminLoginExists(id))
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

        // POST: api/AdminLogin
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AdminLogin>> PostAdminLogin(AdminLogin adminLogin)
        {
            _context.AdminLogins.Add(adminLogin);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (AdminLoginExists(adminLogin.UserName))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetAdminLogin", new { id = adminLogin.UserName }, adminLogin);
        }

        // DELETE: api/AdminLogin/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAdminLogin(string id)
        {
            var adminLogin = await _context.AdminLogins.FindAsync(id);
            if (adminLogin == null)
            {
                return NotFound();
            }

            _context.AdminLogins.Remove(adminLogin);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AdminLoginExists(string id)
        {
            return _context.AdminLogins.Any(e => e.UserName == id);
        }
    }
}
