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
        private const int PageSize = 4;

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
            var query = _context.Assets
            .Include(a => a.Category)
            .Include(a => a.Supplier)
            .AsNoTracking();

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

            var assetResponseDtos = _mapper.Map<List<AssetResponseDto>>(assets);

            return Ok(assetResponseDtos);
        }
        
             [HttpGet("{id}")]
        public async Task<ActionResult<AssetResponseDto>> GetAsset(Guid id)
        {
            var asset = await _context.Assets
                .Include(a => a.Category)
                .Include(a => a.Supplier)
                .FirstOrDefaultAsync(a => a.Id == id);

            var dto = _mapper.Map<AssetResponseDto>(asset);

            if (asset == null)
            {
                return NotFound();
            }
            return dto;
        }
        
        
        [HttpPost]
        public async Task<ActionResult<AssetResponseDto>> PostAsset(AssetCreateDto dto)
        {  

            if (dto == null)
            {
                return BadRequest("Asset data is required");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var asset = _mapper.Map<Asset>(dto);
            var supplier = await _context.Suppliers.FindAsync(dto.SupplierId);
            if (supplier == null)
            {
                return BadRequest("Supplier not found");
            }
            asset.Supplier = supplier;
            var category = await _context.Categories.FindAsync(dto.CategoryId);
            if (category == null)
            {
                return BadRequest("Category not found");
            }
            asset.Category = category;

            _context.Assets.Add(asset);


            await _context.SaveChangesAsync(); 

            var assetResponseDto = _mapper.Map<AssetResponseDto>(asset);
            var supplierResponseDto = _mapper.Map<SupplierResponseDto>(asset.Supplier);
            var categoryResponseDto = _mapper.Map<CategoryResponseDto>(asset.Category);

            var responseAssetDto = new
            {
                Asset = assetResponseDto,
                Supplier = supplierResponseDto,
                Category = categoryResponseDto
            };

            return CreatedAtAction(nameof(GetAsset), new { id = asset.Id }, responseAssetDto);
        }   
 
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsset(Guid id, AssetUpdateDto dto)
        {
            if (dto == null)
            {
                return BadRequest("Asset data is required");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var asset = await _context.Assets
                .Include(a => a.Supplier)
                .Include(a => a.Category)
                .FirstOrDefaultAsync(a => a.Id == id);

            if (asset == null)
            {
                return NotFound();
            }

            // Validate Supplier
            var supplier = await _context.Suppliers.FindAsync(dto.SupplierId);
            if (supplier == null)
            {
                return BadRequest("Supplier not found");
            }

            // Validate Category
            var category = await _context.Categories.FindAsync(dto.CategoryId);
            if (category == null)
            {
                return BadRequest("Category not found");
            }

            _mapper.Map(dto, asset);
            asset.Supplier = supplier;
            asset.Category = category;
            await _context.SaveChangesAsync();
            return Ok(_mapper.Map<AssetResponseDto>(asset));
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
            return Ok(_mapper.Map<AssetResponseDto>(asset));
        }
        
        
    }
    
}