using System.ComponentModel.DataAnnotations;

namespace AssetManagementSystem.Dtos
{
    public class CategoryCreateDto 
    {
        [StringLength(25)]
        public string Name { get; set; }

        [StringLength(50)]
        public string CreatedBy { get; set; }

        public bool Active { get; set; }
        [StringLength(50)]
        public string Kilogram { get; set; }
    }
}