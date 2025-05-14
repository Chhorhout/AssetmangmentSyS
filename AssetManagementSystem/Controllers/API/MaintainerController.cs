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

        public MaintainerController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Maintainer>>> GetMaintainers()
        {
            var maintainers = await _context.Maintainers.ToListAsync();
            return Ok(maintainers);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Maintainer>> GetMaintainer(Guid id)
        {
            var maintainer = await _context.Maintainers.FindAsync(id);
            return Ok(maintainer);
        }

        [HttpPost]
        public async Task<ActionResult<Maintainer>> PostMaintainer(MaintainerCreateDto dto)
        {
            var maintainer = _mapper.Map<Maintainer>(dto);
            await _context.Maintainers.AddAsync(maintainer);
            await _context.SaveChangesAsync();
            return Ok(maintainer);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutMaintainer(Guid id, MaintainerCreateDto dto)
        {
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
