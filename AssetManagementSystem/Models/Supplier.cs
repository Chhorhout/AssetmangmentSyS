
using System.ComponentModel.DataAnnotations;

namespace AssetManagementSystem.Models
{
    public class Supplier
    {
        public Guid Id { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(50)]
        public string PhoneNumber { get; set; }

        public bool Active { get; set; }

        public ICollection<Asset> Assets { get; set; }
    
        
    }
}