using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace MurrcatConsole.MurrcatModel
{
    public partial class MurrrcatContext : DbContext
    {
        public MurrrcatContext()
        {
        }

        public MurrrcatContext(DbContextOptions<MurrrcatContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cat> Cats { get; set; }
        public virtual DbSet<CatCategory> CatCategories { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Owner> Owners { get; set; }
        public virtual DbSet<VwCatsWithCategory> VwCatsWithCategories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Environment.GetEnvironmentVariable("MurrrcatDb_ConnectionStrng"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Cyrillic_General_CI_AS");

            modelBuilder.Entity<Cat>(entity =>
            {
                entity.ToTable("Cat");

                entity.HasIndex(e => e.Name, "UQ__Cat__737584F689B1DB45")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Description).HasColumnType("ntext");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.OldPrice).HasColumnType("decimal(12, 2)");

                entity.Property(e => e.Price).HasColumnType("decimal(12, 2)");

                entity.HasOne(d => d.OwnerNavigation)
                    .WithMany(p => p.Cats)
                    .HasForeignKey(d => d.Owner)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Cat__Owner__5812160E");
            });

            modelBuilder.Entity<CatCategory>(entity =>
            {
                entity.HasKey("Cat", "Category");

                entity.ToTable("Cat_Category");

                entity.Property(e => e.Cat)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.CatNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.Cat)
                    .HasConstraintName("FK__Cat_Categor__Cat__534D60F1");

                entity.HasOne(d => d.CategoryNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.Category)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Cat_Categ__Categ__5441852A");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Category");

                entity.Property(e => e.Description).HasColumnType("ntext");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Owner>(entity =>
            {
                entity.ToTable("Owner");

                entity.Property(e => e.Contacts)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<VwCatsWithCategory>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vwCatsWithCategories");

                entity.Property(e => e.CatName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CategoriesNames).HasMaxLength(4000);

                entity.Property(e => e.Id)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
