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
    public class AssetsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;


        public AssetsController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Asset>>> GetAssets()
        {
            return await _context.Assets.ToListAsync();
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<Asset>> GetAsset(Guid id)
        {
            var asset = await _context.Assets.FindAsync(id);
            if (asset == null)
            {
                return NotFound();
            }
            return asset;
        }
        
        [HttpPost]
        public async Task<ActionResult<Asset>> PostAsset(AssetCreateDto dto)
        {  
            if (dto == null)
            {
                return BadRequest("Asset data is required");
            }

            var asset = _mapper.Map<Asset>(dto);
            _context.Assets.Add(asset);
            await _context.SaveChangesAsync(); 
            return CreatedAtAction(nameof(GetAsset), new { id = asset.Id }, asset);
        }   
        
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsset(Guid id, AssetCreateDto dto)
        {
            if (dto == null)
            {
                return BadRequest("Asset data is required");
            }   
            var asset = await _context.Assets.FindAsync(id);
            if (asset == null)
            {
                return NotFound();
            }
            _mapper.Map(dto, asset);
            await _context.SaveChangesAsync();
            return Ok(asset);
        }
        
        
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsset(Guid id)
        {
            var asset = await _context.Assets.FindAsync(id);
            if (asset == null)
            {
                return NotFound();
            }
            _context.Assets.Remove(asset);
            await _context.SaveChangesAsync();
            return Ok(asset);
        }
        
        
    }
    
}