﻿using System.ComponentModel.DataAnnotations;

namespace AssetManagementSystem.Dtos
{
    public class AssetCreateDto
    {
        [StringLength(50)]
        public string Name { get; set; }
        public string SerialNumber { get; set; }
        public string Location { get; set; }
        public bool Active { get; set; }    
        public bool HaveWarranty { get; set; }
        public DateTime? WarrantyStartDate { get; set; }
        public DateTime? WarrantyEndDate { get; set; }
        public Guid CategoryId { get; set; }
        public Guid SupplierId { get; set; }
        public string ImageUrl { get; set; }
    }

}