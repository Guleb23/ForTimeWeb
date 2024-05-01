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
    public class ProviderController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public ProviderController(ApplicationDBContext context)
        {
            _context = context;
        }

        // GET: api/Providers
        [HttpGet("/GetAllProviders")]
        public async Task<ActionResult<IEnumerable<Provider>>> GetProvider()
        {
            return await _context.Provider.ToListAsync();
        }

        [HttpGet("LoginUser/{userPhone}/{userPassword}")]
        public async Task<ActionResult<Provider>> LoginUser(string userPhone, string userPassword)
        {
            var user = await _context.Provider.FirstOrDefaultAsync(u => u.Login == userPhone && u.Password == userPassword);

            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);


        }


        [HttpPost("/CreateProvider")]
        public async Task<ActionResult<Provider>> PostProvider(Provider provider)
        {
            _context.Provider.Add(provider);
            await _context.SaveChangesAsync();

            return Ok(provider);
        }

        
    }
}
