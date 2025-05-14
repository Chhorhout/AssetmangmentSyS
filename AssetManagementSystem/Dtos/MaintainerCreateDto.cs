using System.ComponentModel.DataAnnotations;

namespace AssetManagementSystem.Dtos
{
    public class MaintainerCreateDto
    {
        [StringLength(50)]
        public  string Name { get; set; }

        
        [StringLength(50)]
        public  string Email { get; set; }

        [StringLength(50)]
        public  string PhoneNumber { get; set; }

        
        public  bool Active { get; set; }

        [StringLength(50)]
        public  string City { get; set; }
    }
}