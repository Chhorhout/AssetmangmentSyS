using System.ComponentModel.DataAnnotations;

namespace AssetManagementSystem.Models;

public class User
{
    public Guid Id { get; set; }

    public required string Name { get; set; }

    public required string Email { get; set; }

    public required string Password { get; set; }

    public required string Role { get; set; }

    public bool Active { get; set; }

    public DateTime CreatedAt { get; set; }
}
