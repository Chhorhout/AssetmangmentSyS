using System.ComponentModel.DataAnnotations;

namespace AssetManagementSystem.Models
{
    public class Maintainer
    {
        public Guid Id { get; set; }

       
        public  string Name { get; set; }

   
        public  string Email { get; set; }

       
        public  string PhoneNumber { get; set; }

        
        public  bool Active { get; set; }

       
        public  string City { get; set; }
        
    }
}
