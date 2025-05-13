using System.ComponentModel.DataAnnotations;

namespace AssetManagementSystem.Models
{
    public class Maintainer
    {
        public Guid Id { get; set; }

       
        public required string Name { get; set; }

   
        public required string Email { get; set; }

       
        public required string PhoneNumber { get; set; }

        
        public required bool Active { get; set; }

       
        public required string City { get; set; }
        
    }
}
