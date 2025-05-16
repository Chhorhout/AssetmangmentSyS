using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace AssetManagementSystem.Models
{
    public class Category
    {
        public Guid Id { get; set; }

        [StringLength(25)]
        public string Name { get; set; }

        [StringLength(50)]
        public string CreatedBy { get; set; }

        public bool Active { get; set; }
        [StringLength(50)]
        public string Kilogram { get; set; }

        // Navigation properties
        public ICollection<Asset> Assets { get; set; }
    }
}
