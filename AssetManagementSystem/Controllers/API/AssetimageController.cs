using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading.Tasks;

namespace AssetManagementSystem.Controllers.API;

[Route("api/[controller]")]
[ApiController]
public class ImageController : ControllerBase
{
    public ImageController()
    {
    }

    [HttpPost]
    public async Task<IActionResult> Upload(IFormFile file)
    {
        if (file == null)
        {
            return BadRequest("No file uploaded");
        }

        var allowedExtensions = new[] { 
            ".jpg", ".jpeg", ".png", ".gif", ".webp", 
            ".bmp", ".tiff", ".tif", ".svg", ".ico"
        };
        var extension = Path.GetExtension(file.FileName).ToLowerInvariant();
        if (!allowedExtensions.Contains(extension))
        {
            return BadRequest("Invalid file extension. Allowed formats: JPG, JPEG, PNG, GIF, WebP, BMP, TIFF, SVG, ICO");
        }

        var uploadsDirectory = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads");


        if (!Directory.Exists(uploadsDirectory))
        {
            Directory.CreateDirectory(uploadsDirectory);
        }

        var fileName = Guid.NewGuid().ToString() + extension;
        var filePath = Path.Combine(uploadsDirectory, fileName);

        using (var stream = new FileStream(filePath, FileMode.Create))
        {
            await file.CopyToAsync(stream); 
        }

        var filePathOnServer = $"/uploads/{fileName}";
        var fileUrl = $"{Request.Scheme}://{Request.Host}{filePathOnServer}";

        return Ok(new { fileName = fileName, fileUrl = fileUrl });
    }
}   