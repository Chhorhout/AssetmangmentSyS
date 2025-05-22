using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AssetManagementSystem.Models
{
    public class Asset
    {
        public Guid Id { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(25)]
        [Display(Name="Serial Number")]
        public string SerialNumber { get; set; }

        [StringLength(50)]
        public string Location { get; set; }
        public bool Active { get; set; }
        public bool HaveWarranty { get; set; }
        public DateTime? WarrantyStartDate { get; set; }
        public DateTime? WarrantyEndDate { get; set; }
        public string? ImageUrl { get; set; }

        public Guid SupplierId { get; set; }

        public Supplier Supplier { get; set; }

        // Navigation properties
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
        