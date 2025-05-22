namespace AssetManagementSystem.Dtos;

public class SupplierResponseDto
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public string Email { get; set; }

    public string PhoneNumber { get; set; }

    public bool Active { get; set; }
}
