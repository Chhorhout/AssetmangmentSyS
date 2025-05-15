using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AssetManagementSystem.Data;
using AssetManagementSystem.Models;
using AssetManagementSystem.Dtos;
using AutoMapper;

namespace AssetManagementSystem.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private const int PageSize = 10;    

        public CategoriesController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetCategories(
            int? page,
            string? searchTerm,
            string? searchBy = "name")
        {
            int pageNumber = page ?? 1;
            var query = _context.Categories.AsNoTracking();

            // Apply search filter if searchTerm is provided
            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                searchTerm = searchTerm.ToLower();
                switch (searchBy.ToLower())
                {
                    case "name":
                        query = query.Where(c => c.Name.ToLower().Contains(searchTerm));
                        break;
                    case "createdby":
                        query = query.Where(c => c.CreatedBy.ToLower().Contains(searchTerm));
                        break;
                    case "kilogram":
                        query = query.Where(c => c.Kilogram.ToLower().Contains(searchTerm));
                        break;
                    default:
                        query = query.Where(c => c.Name.ToLower().Contains(searchTerm) || 
                                               c.CreatedBy.ToLower().Contains(searchTerm) ||
                                               c.Kilogram.ToLower().Contains(searchTerm));
                        break;
                }
            }

            var totalItems = await query.CountAsync();
            var totalPages = (int)Math.Ceiling(totalItems / (double)PageSize);

            var categories = await query
                .Skip((pageNumber - 1) * PageSize)
                .Take(PageSize)
                .ToListAsync();

            Response.Headers.Add("X-Total-Count", totalItems.ToString());
            Response.Headers.Add("X-Total-Pages", totalPages.ToString());
            Response.Headers.Add("X-Current-Page", pageNumber.ToString());
            Response.Headers.Add("X-Page-Size", PageSize.ToString());

            return categories;
        }
        
        
        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetCategory(Guid id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            return category;
        }
        
        [HttpPost]
        public async Task<IActionResult> PostCategory(CategoryCreateDto dto)
        {
            if (dto == null)
            {
                return BadRequest("Category data is required");
            }   
            var category = _mapper.Map<Category>(dto);
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetCategory), new { id = category.Id }, category);
           

        }
         
        
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategory(Guid id, CategoryCreateDto dto)
        {
            if (dto == null)
            {
                return BadRequest("Category data is required");
            }   
            var category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            _mapper.Map(dto, category);
            await _context.SaveChangesAsync();
            return Ok(category);
        }
        
        
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(Guid id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
            return Ok(category);
        }
        
    }
}
