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
        private const int PageSize = 10;

        public AssetsController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Asset>>> GetAssets(
            int? page,
            string? searchTerm,
            string? searchBy = "name")
        {
            int pageNumber = page ?? 1;
            var query = _context.Assets.AsNoTracking();

            // Apply search filter if searchTerm is provided
            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                searchTerm = searchTerm.ToLower();
                switch (searchBy.ToLower())
                {
                    case "name":
                        query = query.Where(a => a.Name.ToLower().Contains(searchTerm));
                        break;
                    case "serialnumber":
                        query = query.Where(a => a.SerialNumber.ToLower().Contains(searchTerm));
                        break;
                    case "warranty":
                        if (bool.TryParse(searchTerm, out bool hasWarranty))
                        {
                            query = query.Where(a => a.HaveWarranty == hasWarranty);
                        }
                        break;
                    case "active":
                        if (bool.TryParse(searchTerm, out bool isActive))
                        {
                            query = query.Where(a => a.Active == isActive);
                        }
                        break;
                    default:
                        query = query.Where(a => a.Name.ToLower().Contains(searchTerm) || 
                                               a.SerialNumber.ToLower().Contains(searchTerm));
                        break;
                }
            }
       
        


            var totalItems = await query.CountAsync();
            var totalPages = (int)Math.Ceiling(totalItems / (double)PageSize);

            var assets = await query
                .Skip((pageNumber - 1) * PageSize)
                .Take(PageSize)
                .ToListAsync();

            Response.Headers.Add("X-Total-Count", totalItems.ToString());
            Response.Headers.Add("X-Total-Pages", totalPages.ToString());
            Response.Headers.Add("X-Current-Page", pageNumber.ToString());
            Response.Headers.Add("X-Page-Size", PageSize.ToString());

            return assets;
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
            return CreatedAtAction(nameof(GetAssets), new { id = asset.Id }, asset);
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