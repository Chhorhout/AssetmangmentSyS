using Microsoft.EntityFrameworkCore;
using AssetManagementSystem.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace AssetManagementSystem.Config
{
    public class AssetConfig : IEntityTypeConfiguration<Asset>
    {
        public void Configure(EntityTypeBuilder<Asset> builder)
        {
            builder.HasKey(a => a.Id);
        
            builder.Property(a => a.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(a => a.SerialNumber)
                .IsRequired()
                .HasMaxLength(25);

            builder.Property(a => a.Active)
                .IsRequired()
                .HasDefaultValue(true);

            builder.Property(a => a.HaveWarranty)
                .IsRequired()
                .HasDefaultValue(false);

            builder.HasOne(a => a.Category)
                .WithMany(c => c.Assets)
                .HasForeignKey(a => a.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(a => a.Supplier)
                .WithMany(s => s.Assets)
                .HasForeignKey(a => a.SupplierId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
