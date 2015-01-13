using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Neemo.CarParts.EntityFramework.Models.Mapping
{
    public class WreckMap : EntityTypeConfiguration<Wreck>
    {
        public WreckMap()
        {
            // Primary Key
            this.HasKey(t => t.WreckID);

            // Properties
            this.Property(t => t.WreckNo)
                .HasMaxLength(100);

            this.Property(t => t.KeyWord)
                .HasMaxLength(100);

            this.Property(t => t.Image)
                .HasMaxLength(100);

            this.Property(t => t.CreatedByUser)
                .HasMaxLength(50);

            this.Property(t => t.LastModifiedByUser)
                .HasMaxLength(50);

            this.Property(t => t.DeletedByUser)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Wreck");
            this.Property(t => t.WreckID).HasColumnName("WreckID");
            this.Property(t => t.WreckNo).HasColumnName("WreckNo");
            this.Property(t => t.KeyWord).HasColumnName("KeyWord");
            this.Property(t => t.MakeID).HasColumnName("MakeID");
            this.Property(t => t.ModelID).HasColumnName("ModelID");
            this.Property(t => t.ChassisID).HasColumnName("ChassisID");
            this.Property(t => t.EngineID).HasColumnName("EngineID");
            this.Property(t => t.EngineSizeID).HasColumnName("EngineSizeID");
            this.Property(t => t.FuelTypeID).HasColumnName("FuelTypeID");
            this.Property(t => t.BodyTypeID).HasColumnName("BodyTypeID");
            this.Property(t => t.WheelBaseID).HasColumnName("WheelBaseID");
            this.Property(t => t.YearID).HasColumnName("YearID");
            this.Property(t => t.Image).HasColumnName("Image");
            this.Property(t => t.Active).HasColumnName("Active");
            this.Property(t => t.CreatedDateTime).HasColumnName("CreatedDateTime");
            this.Property(t => t.CreatedByUser).HasColumnName("CreatedByUser");
            this.Property(t => t.LastModifiedDateTime).HasColumnName("LastModifiedDateTime");
            this.Property(t => t.LastModifiedByUser).HasColumnName("LastModifiedByUser");
            this.Property(t => t.DeletedDateTime).HasColumnName("DeletedDateTime");
            this.Property(t => t.DeletedByUser).HasColumnName("DeletedByUser");
            this.Property(t => t.EffectiveDateFrom).HasColumnName("EffectiveDateFrom");
            this.Property(t => t.EffectiveDateTo).HasColumnName("EffectiveDateTo");

            // Relationships
            this.HasOptional(t => t.BodyType)
                .WithMany(t => t.Wrecks)
                .HasForeignKey(d => d.BodyTypeID);
            this.HasOptional(t => t.Chassis)
                .WithMany(t => t.Wrecks)
                .HasForeignKey(d => d.ChassisID);
            this.HasOptional(t => t.Engine)
                .WithMany(t => t.Wrecks)
                .HasForeignKey(d => d.EngineID);
            this.HasOptional(t => t.EngineSize)
                .WithMany(t => t.Wrecks)
                .HasForeignKey(d => d.EngineSizeID);
            this.HasOptional(t => t.FuelType)
                .WithMany(t => t.Wrecks)
                .HasForeignKey(d => d.FuelTypeID);
            this.HasOptional(t => t.Make)
                .WithMany(t => t.Wrecks)
                .HasForeignKey(d => d.MakeID);
            this.HasOptional(t => t.Model)
                .WithMany(t => t.Wrecks)
                .HasForeignKey(d => d.ModelID);
            this.HasOptional(t => t.WheelBase)
                .WithMany(t => t.Wrecks)
                .HasForeignKey(d => d.WheelBaseID);
            this.HasOptional(t => t.Year)
                .WithMany(t => t.Wrecks)
                .HasForeignKey(d => d.YearID);

        }
    }
}
