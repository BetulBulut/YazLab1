using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeyzaNurCansever.OneDrive.Masaüstü.YazLab1.ShopApp.ShopApp.entity;
using Microsoft.EntityFrameworkCore;

namespace BeyzaNurCansever.OneDrive.Masaüstü.YazLab1.ShopApp.ShopApp.Data.Concrete
{
    public partial class ShopContext : DbContext
    {




        public ShopContext()
        {
        }

        public ShopContext(DbContextOptions<ShopContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Laptop> Laptops { get; set; }
        public virtual DbSet<LaptopSite> LaptopSites { get; set; }
        public virtual DbSet<Site> Sites { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=shopDb");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Laptop>(entity =>
            {
                entity.ToTable("Laptop");

                entity.Property(e => e.Id).HasMaxLength(50);

                entity.Property(e => e.DiskBoyutu)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("Disk_boyutu")
                    .IsFixedLength(true);

                entity.Property(e => e.DiskTuru)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("Disk_türü")
                    .IsFixedLength(true);

                entity.Property(e => e.EkranBoyutu)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("Ekran_boyutu")
                    .IsFixedLength(true);

                entity.Property(e => e.IslemciTipi)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("Islemci_tipi")
                    .IsFixedLength(true);

                entity.Property(e => e.IsletimSistemi)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("Isletim_sistemi")
                    .IsFixedLength(true);

                entity.Property(e => e.Marka)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.ModelAdı)
                    .IsRequired()
                    .HasColumnName("Model_adı");

                entity.Property(e => e.Ram)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<LaptopSite>(entity =>
            {
                entity.HasKey(e => new { e.SiteId, e.LaptopId })
                    .HasName("PK_ModelSite");

                entity.ToTable("LaptopSite");

                entity.Property(e => e.LaptopId).HasMaxLength(50);

                entity.Property(e => e.Details).IsRequired();

                entity.Property(e => e.ImgUrl).IsRequired();

                entity.HasOne(d => d.Laptop)
                    .WithMany(p => p.LaptopSites)
                    .HasForeignKey(d => d.LaptopId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ModelSite_Model");

                entity.HasOne(d => d.Site)
                    .WithMany(p => p.LaptopSites)
                    .HasForeignKey(d => d.SiteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ModelSite_Site");
            });

            modelBuilder.Entity<Site>(entity =>
            {
                entity.ToTable("Site");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsFixedLength(true);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}


