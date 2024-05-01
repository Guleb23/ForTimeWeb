using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EmelyanovDiplom;
using EmelyanovDiplom.Models;
using Microsoft.Data.SqlClient;

namespace EmelyanovDiplom.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public ClientController(ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpGet("/GetAllClients")]
        public async Task<ActionResult<IEnumerable<Client>>> GetClient()
        {
            return await _context.Client.ToListAsync();
        }

        // GET: api/Clients/5
        [HttpGet("/GetAllClientsById/{clientId}")]
        public async Task<ActionResult<Client>> GetClient(int clientId)
        {
            var client = await _context.Client.FindAsync(clientId);

            if (client == null)
            {
                return NotFound();
            }

            return client;
        }

        [HttpPut("/UpdateClient")]
        public async Task<IActionResult> PutClient(Client client)
        {
            _context.Entry(client).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpPost("/CreateClient")]
        public async Task<ActionResult<Client>> PostClient(Client client)
        {
            _context.Client.Add(client);
            await _context.SaveChangesAsync();

            return Ok(client);
        }

        [HttpGet("LoginClient/{userPhone}/{userPassword}")]
        public async Task<ActionResult<Client>> LoginUser(string userPhone, string userPassword)
        {
            var user = await _context.Client.FirstOrDefaultAsync(u => u.Phone == userPhone && u.Password == userPassword);
            
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);


        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClient(int id)
        {
            var client = await _context.Client.FindAsync(id);
            if (client == null)
            {
                return NotFound();
            }

            _context.Client.Remove(client);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}
