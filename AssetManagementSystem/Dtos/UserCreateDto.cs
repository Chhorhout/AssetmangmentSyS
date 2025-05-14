using System.ComponentModel.DataAnnotations;

namespace AssetManagementSystem.Dtos
{
    public class UserCreateDto
    {
        
    public string Name { get; set; }

    public string Email { get; set; }

    public  string Password { get; set; }

    public  string Role { get; set; }

    public bool Active { get; set; }
    }
}