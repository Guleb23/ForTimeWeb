using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EmelyanovDiplom;
using EmelyanovDiplom.Models;

namespace EmelyanovDiplom.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UslugController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public UslugController(ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpGet("/GetAllUslugi")]
        public async Task<ActionResult<IEnumerable<Uslugi>>> GetUslugi()
        {
            return await _context.Uslugi.ToListAsync();
        }

        [HttpGet("/GetUslugiById/{providerId}")]
        public async Task<ActionResult<Uslugi>> GetUslugi(int providerId)
        {
            var uslugi = await _context.Uslugi.FirstOrDefaultAsync(u => u.Provider == providerId);

            if (uslugi == null)
            {
                return NotFound();
            }

            return uslugi;
        }

        [HttpPost("/CreateUslugu")]
        public async Task<ActionResult<Uslugi>> PostUslugi(Uslugi uslugi)
        {
            _context.Uslugi.Add(uslugi);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUslugi", new { id = uslugi.Id }, uslugi);
        }
    }
}
