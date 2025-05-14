using System.ComponentModel.DataAnnotations;

namespace AssetManagementSystem.Dtos
{
    public class AssetCreateDto
    {
        [StringLength(50)]
        public string Name { get; set; }
        public string SerialNumber { get; set; }
        public bool Active { get; set; }
        public bool HaveWarranty { get; set; }
        public DateTime? WarrantyStartDate { get; set; }
        public DateTime? WarrantyEndDate { get; set; }
    }
}