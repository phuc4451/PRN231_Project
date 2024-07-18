using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Project_PRN231_API.Models
{
    public partial class FarmManagement2_PRN231Context : DbContext
    {
        public FarmManagement2_PRN231Context()
        {
        }

        public FarmManagement2_PRN231Context(DbContextOptions<FarmManagement2_PRN231Context> options)
            : base(options)
        {
        }

        public virtual DbSet<CareProcess> CareProcesses { get; set; } = null!;
        public virtual DbSet<Crop> Crops { get; set; } = null!;
        public virtual DbSet<HarvestProcess> HarvestProcesses { get; set; } = null!;
        public virtual DbSet<PlantProcess> PlantProcesses { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<SaleProcess> SaleProcesses { get; set; } = null!;
        public virtual DbSet<Storage> Storages { get; set; } = null!;
        public virtual DbSet<StorageAllocation> StorageAllocations { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=(local);database=FarmManagement2_PRN231;Trusted_Connection=SSPI;Encrypt=false;TrustServerCertificate=true");

                 optionsBuilder
                    .UseSqlServer("DB")
                    .ConfigureWarnings(warnings => warnings.Ignore(CoreEventId.NavigationBaseIncludeIgnored));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CareProcess>(entity =>
            {
                entity.ToTable("CareProcess");

                entity.Property(e => e.CareProcessId).HasColumnName("CareProcessID");

                entity.Property(e => e.CompletionDate).HasColumnType("date");

                entity.Property(e => e.CompletionStatus).HasMaxLength(20);

                entity.Property(e => e.CropId).HasColumnName("CropID");

                entity.Property(e => e.DueDate).HasColumnType("date");

                entity.Property(e => e.MaterialsUsed).HasMaxLength(255);

                entity.Property(e => e.TaskDescription).HasMaxLength(255);

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Crop)
                    .WithMany(p => p.CareProcesses)
                    .HasForeignKey(d => d.CropId)
                    .HasConstraintName("FK_CareProcess_Crops");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.CareProcesses)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_CareProcess_Users");
            });

            modelBuilder.Entity<Crop>(entity =>
            {
                entity.Property(e => e.CropId).HasColumnName("CropID");

                entity.Property(e => e.CropName).HasMaxLength(100);

                entity.Property(e => e.CropType).HasMaxLength(50);

                entity.Property(e => e.Status).HasMaxLength(20);
            });

            modelBuilder.Entity<HarvestProcess>(entity =>
            {
                entity.ToTable("HarvestProcess");

                entity.Property(e => e.HarvestProcessId).HasColumnName("HarvestProcessID");

                entity.Property(e => e.CropId).HasColumnName("CropID");

                entity.Property(e => e.HarvestDate).HasColumnType("date");

                entity.Property(e => e.QuantityHarvested).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Crop)
                    .WithMany(p => p.HarvestProcesses)
                    .HasForeignKey(d => d.CropId)
                    .HasConstraintName("FK_HarvestProcess_Crops");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.HarvestProcesses)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_HarvestProcess_Users");
            });

            modelBuilder.Entity<PlantProcess>(entity =>
            {
                entity.ToTable("PlantProcess");

                entity.Property(e => e.PlantProcessId).HasColumnName("PlantProcessID");

                entity.Property(e => e.CropId).HasColumnName("CropID");

                entity.Property(e => e.ExpectedHarvestDate).HasColumnType("date");

                entity.Property(e => e.PlantingDate).HasColumnType("date");

                entity.Property(e => e.Quantity).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Crop)
                    .WithMany(p => p.PlantProcesses)
                    .HasForeignKey(d => d.CropId)
                    .HasConstraintName("FK_PlantProcess_Crops");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.PlantProcesses)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_PlantProcess_Users");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasIndex(e => e.RoleName, "UQ__Roles__8A2B616086FFB5D7")
                    .IsUnique();

                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.Property(e => e.RoleName).HasMaxLength(50);
            });

            modelBuilder.Entity<SaleProcess>(entity =>
            {
                entity.ToTable("SaleProcess");

                entity.Property(e => e.SaleProcessId).HasColumnName("SaleProcessID");

                entity.Property(e => e.Destination).HasMaxLength(255);

                entity.Property(e => e.Quantity).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.SaleDate).HasColumnType("date");

                entity.Property(e => e.StorageId).HasColumnName("StorageID");

                entity.HasOne(d => d.Storage)
                    .WithMany(p => p.SaleProcesses)
                    .HasForeignKey(d => d.StorageId)
                    .HasConstraintName("FK_SaleProcess_Storage");
            });

            modelBuilder.Entity<Storage>(entity =>
            {
                entity.ToTable("Storage");

                entity.Property(e => e.StorageId).HasColumnName("StorageID");

                entity.Property(e => e.Capacity).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.StorageName).HasMaxLength(100);
            });

            modelBuilder.Entity<StorageAllocation>(entity =>
            {
                entity.ToTable("StorageAllocation");

                entity.Property(e => e.StorageAllocationId).HasColumnName("StorageAllocationID");

                entity.Property(e => e.HarvestProcessId).HasColumnName("HarvestProcessID");

                entity.Property(e => e.Quantity).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.StorageId).HasColumnName("StorageID");

                entity.HasOne(d => d.HarvestProcess)
                    .WithMany(p => p.StorageAllocations)
                    .HasForeignKey(d => d.HarvestProcessId)
                    .HasConstraintName("FK_StorageAllocation_HarvestProcess");

                entity.HasOne(d => d.Storage)
                    .WithMany(p => p.StorageAllocations)
                    .HasForeignKey(d => d.StorageId)
                    .HasConstraintName("FK_StorageAllocation_Storage");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.Username, "UQ__Users__536C85E4529A5001")
                    .IsUnique();

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.PasswordHash).HasMaxLength(256);

                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.Property(e => e.Username).HasMaxLength(50);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_Users_Roles");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
