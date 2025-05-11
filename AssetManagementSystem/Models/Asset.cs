using System.ComponentModel.DataAnnotations;

namespace AssetManagementSystem.Models
{
    public class Asset
    {
        public required Guid Id { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(25)]
        [Display(Name="Serial Number")]
        public string SerialNumber { get; set; }
        public bool Active { get; set; }
        public bool HaveWarranty { get; set; }
        public DateTime? WarrantyStartDate { get; set; }
        public DateTime? WarrantyEndDate { get; set; }
    }
}