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
    public class MaintainerController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private const int PageSize = 7;

        public MaintainerController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Maintainer>>> GetMaintainers(
            int? page,
            string? searchTerm,
            string? searchBy = "name")
        {
            int pageNumber = page ?? 1;
            var query = _context.Maintainers.AsNoTracking();

            // Apply search filter if searchTerm is provided
            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                searchTerm = searchTerm.ToLower();
                switch (searchBy.ToLower())
                {
                    case "name":
                        query = query.Where(m => m.Name.ToLower().Contains(searchTerm));
                        break;
                    case "email":
                        query = query.Where(m => m.Email.ToLower().Contains(searchTerm));
                        break;
                    case "phonenumber":
                        query = query.Where(m => m.PhoneNumber.ToLower().Contains(searchTerm));
                        break;
                    case "city":
                        query = query.Where(m => m.City.ToLower().Contains(searchTerm));
                        break;
                    case "active":
                        if (bool.TryParse(searchTerm, out bool isActive))
                        {
                            query = query.Where(m => m.Active == isActive);
                        }
                        break;
                    default:
                        query = query.Where(m => m.Name.ToLower().Contains(searchTerm) || 
                                               m.Email.ToLower().Contains(searchTerm) ||
                                               m.PhoneNumber.ToLower().Contains(searchTerm) ||
                                               m.City.ToLower().Contains(searchTerm));
                        break;
                }
            }

            var totalItems = await query.CountAsync();
            var totalPages = (int)Math.Ceiling(totalItems / (double)PageSize);

            var maintainers = await query
                .Skip((pageNumber - 1) * PageSize)
                .Take(PageSize)
                .ToListAsync();

            Response.Headers.Add("X-Total-Count", totalItems.ToString());
            Response.Headers.Add("X-Total-Pages", totalPages.ToString());
            Response.Headers.Add("X-Current-Page", pageNumber.ToString());
            Response.Headers.Add("X-Page-Size", PageSize.ToString());

            return maintainers;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Maintainer>> GetMaintainer(Guid id)
        {
            var maintainer = await _context.Maintainers.FindAsync(id);
            if (maintainer == null)
            {
                return NotFound();
            }
            return maintainer;
        }

        [HttpPost]
        public async Task<ActionResult<Maintainer>> PostMaintainer(MaintainerCreateDto dto)
        {
            if (dto == null)
            {
                return BadRequest("Maintainer data is required");
            }

            var maintainer = _mapper.Map<Maintainer>(dto);
            await _context.Maintainers.AddAsync(maintainer);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetMaintainer), new { id = maintainer.Id }, maintainer);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutMaintainer(Guid id, MaintainerCreateDto dto)
        {
            if (dto == null)
            {
                return BadRequest("Maintainer data is required");
            }

            var maintainer = await _context.Maintainers.FindAsync(id);
            if (maintainer == null)
            {
                return NotFound();
            }

            _mapper.Map(dto, maintainer);
            await _context.SaveChangesAsync();
            return Ok(maintainer);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMaintainer(Guid id)
        {
            var maintainer = await _context.Maintainers.FindAsync(id);
            if (maintainer == null)
            {
                return NotFound();
            }
            _context.Maintainers.Remove(maintainer);
            await _context.SaveChangesAsync();
            return Ok(maintainer);
        }
    }
}
