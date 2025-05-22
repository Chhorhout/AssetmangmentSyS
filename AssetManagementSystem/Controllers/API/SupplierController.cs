using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AssetManagementSystem.Data;
using AssetManagementSystem.Models;
using AssetManagementSystem.Dtos;
using AutoMapper;
using System.ComponentModel.DataAnnotations;

namespace AssetManagementSystem.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private const int PageSize = 7;

        public SupplierController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SupplierResponseDto>>> GetSuppliers(
            int? page,
            string? searchTerm,
            string? searchBy = "name")
        {
            int pageNumber = page ?? 1;
            var query = _context.Suppliers.AsNoTracking();

            // Apply search filter if searchTerm is provided
            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                searchTerm = searchTerm.ToLower();
                switch (searchBy.ToLower())
                {
                    case "name":
                        query = query.Where(s => s.Name.ToLower().Contains(searchTerm));
                        break;
                    case "email":
                        query = query.Where(s => s.Email.ToLower().Contains(searchTerm));
                        break;
                    case "phonenumber":
                        query = query.Where(s => s.PhoneNumber.ToLower().Contains(searchTerm));
                        break;
                    case "active":
                        if (bool.TryParse(searchTerm, out bool isActive))
                        {
                            query = query.Where(s => s.Active == isActive);
                        }
                        break;
                    default:
                        query = query.Where(s => s.Name.ToLower().Contains(searchTerm) || 
                                               s.Email.ToLower().Contains(searchTerm) ||
                                               s.PhoneNumber.ToLower().Contains(searchTerm));
                        break;
                }
            }

            var totalItems = await query.CountAsync();
            var totalPages = (int)Math.Ceiling(totalItems / (double)PageSize);

            var suppliers = await query
                .Skip((pageNumber - 1) * PageSize)
                .Take(PageSize)
                .ToListAsync();

            Response.Headers.Add("X-Total-Count", totalItems.ToString());
            Response.Headers.Add("X-Total-Pages", totalPages.ToString());
            Response.Headers.Add("X-Current-Page", pageNumber.ToString());
            Response.Headers.Add("X-Page-Size", PageSize.ToString());

            var supplierDtos = _mapper.Map<List<SupplierResponseDto>>(suppliers);
            return Ok(supplierDtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SupplierResponseDto>> GetSupplier(Guid id)
        {
            var supplier = await _context.Suppliers.FindAsync(id);
            if (supplier == null)
            {
                return NotFound();
            }
            var supplierDto = _mapper.Map<SupplierResponseDto>(supplier);
            return Ok(supplierDto);
        }

        [HttpPost]
        public async Task<ActionResult<SupplierCreateDto>> PostSupplier(SupplierCreateDto dto)
        {
            if (dto == null)
            {
                return BadRequest("Supplier data is required");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Validate email format
            if (!new EmailAddressAttribute().IsValid(dto.Email))
            {
                ModelState.AddModelError("Email", "Invalid email format");
                return BadRequest(ModelState);
            }

            var supplier = _mapper.Map<Supplier>(dto);
            await _context.Suppliers.AddAsync(supplier);
            await _context.SaveChangesAsync();

            var supplierDto = _mapper.Map<SupplierCreateDto>(supplier);
            return CreatedAtAction(nameof(GetSupplier), new { id = supplier.Id }, supplierDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutSupplier(Guid id, SupplierCreateDto dto)
        {
            if (dto == null)
            {
                return BadRequest("Supplier data is required");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Validate email format
            if (!new EmailAddressAttribute().IsValid(dto.Email))
            {
                ModelState.AddModelError("Email", "Invalid email format");
                return BadRequest(ModelState);
            }

            var supplier = await _context.Suppliers.FindAsync(id);
            if (supplier == null)
            {
                return NotFound();
            }

            _mapper.Map(dto, supplier);
            await _context.SaveChangesAsync();

            var supplierDto = _mapper.Map<SupplierCreateDto>(supplier);
            return Ok(supplierDto);
        }

        [HttpDelete("{id}")]    
        public async Task<IActionResult> DeleteSupplier(Guid id)
        {
            var supplier = await _context.Suppliers.FindAsync(id);
            if (supplier == null)
            {
                return NotFound();
            }

            var hasAssets = await _context.Assets.AnyAsync(a => a.SupplierId == id);
            if (hasAssets)
            {
                return BadRequest("Cannot delete supplier with associated assets");
            }

            _context.Suppliers.Remove(supplier);
            await _context.SaveChangesAsync();

            var supplierDto = _mapper.Map<SupplierCreateDto>(supplier);
            return Ok(supplierDto);
        }
    }
}