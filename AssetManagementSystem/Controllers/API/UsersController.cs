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
    public class UsersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private const int PageSize = 7;

        public UsersController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers(
            int? page,
            string? searchTerm,
            string? searchBy = "name")
        {
            int pageNumber = page ?? 1;
            var query = _context.Users.AsNoTracking();

            // Apply search filter if searchTerm is provided
            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                searchTerm = searchTerm.ToLower();
                switch (searchBy.ToLower())
                {
                    case "name":
                        query = query.Where(u => u.Name.ToLower().Contains(searchTerm));
                        break;
                    case "email":
                        query = query.Where(u => u.Email.ToLower().Contains(searchTerm));
                        break;
                    case "role":
                        query = query.Where(u => u.Role.ToLower().Contains(searchTerm));
                        break;
                    case "active":
                        if (bool.TryParse(searchTerm, out bool isActive))
                        {
                            query = query.Where(u => u.Active == isActive);
                        }
                        break;
                    default:
                        query = query.Where(u => u.Name.ToLower().Contains(searchTerm) || 
                                               u.Email.ToLower().Contains(searchTerm) ||
                                               u.Role.ToLower().Contains(searchTerm));
                        break;
                }
            }

            var totalItems = await query.CountAsync();
            var totalPages = (int)Math.Ceiling(totalItems / (double)PageSize);

            var users = await query
                .Skip((pageNumber - 1) * PageSize)
                .Take(PageSize)
                .ToListAsync();

            Response.Headers.Add("X-Total-Count", totalItems.ToString());
            Response.Headers.Add("X-Total-Pages", totalPages.ToString());
            Response.Headers.Add("X-Current-Page", pageNumber.ToString());
            Response.Headers.Add("X-Page-Size", PageSize.ToString());

            return users;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(Guid id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return user;
        }

        [HttpPost]
        public async Task<ActionResult<User>> PostUser(UserCreateDto dto)
        {
            if (dto == null)
            {
                return BadRequest("User data is required");
            }

            var user = _mapper.Map<User>(dto);
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(Guid id, UserCreateDto dto)
        {
            if (dto == null)
            {
                return BadRequest("User data is required");
            }

            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _mapper.Map(dto, user);
            await _context.SaveChangesAsync();
            return Ok(user);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return Ok(user);
        }
    }
}