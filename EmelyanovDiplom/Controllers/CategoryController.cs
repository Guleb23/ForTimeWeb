using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EmelyanovApp.Models;
using EmelyanovDiplom;

namespace EmelyanovDiplom.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public CategoryController(ApplicationDBContext context)
        {
            _context = context;
        }

        // GET: api/Categories
        [HttpGet("/GetAllCategory")]
        public async Task<ActionResult<IEnumerable<Category>>> GetCategory()
        {
            return await _context.Category.ToListAsync();
        }

        [HttpGet("/GetCategoryById/{categoryId}")]
        public async Task<ActionResult<Category>> GetCategory(int categoryId)
        {
            var category = await _context.Category.FindAsync(categoryId);

            if (category == null)
            {
                return NotFound();
            }

            return category;
        }
    }
}
