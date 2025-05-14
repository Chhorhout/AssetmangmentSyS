using System.ComponentModel.DataAnnotations;

namespace AssetManagementSystem.Models;

public class User
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public string Email { get; set; }

    public  string Password { get; set; }

    public  string Role { get; set; }

    public bool Active { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;
}
