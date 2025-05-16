namespace AssetManagementSystem.Dtos
{
    public class AssetResponseDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public string SerialNumber { get; set; }

        public bool HaveWarranty { get; set; }

        public DateTime? WarrantyStartDate { get; set; }

        public DateTime? WarrantyEndDate { get; set; }

        public string CategoryName { get; set; }

        public string SupplierName { get; set; }
        
    }
}