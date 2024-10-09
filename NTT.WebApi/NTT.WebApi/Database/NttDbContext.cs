using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace NTT.WebApi.Database;

public partial class NttDbContext : DbContext
{
    public NttDbContext()
    {
    }

    public NttDbContext(DbContextOptions<NttDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<VProdCat> VProdCats { get; set; }

    /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-NCN9KBA;Database=ntt_db;Trusted_Connection=True;TrustServerCertificate=True;");
*/
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__category__3213E83FD468F6D0");

            entity.ToTable("category");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Descr)
                .HasMaxLength(300)
                .HasColumnName("descr");
            entity.Property(e => e.Title)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("title");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__products__3213E83F2CCC5214");

            entity.ToTable("products");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CategoryId).HasColumnName("category_id");
            entity.Property(e => e.Descr)
                .HasMaxLength(300)
                .HasColumnName("descr");
            entity.Property(e => e.Title)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("title");

            entity.HasOne(d => d.Category).WithMany(p => p.Products)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fr_category");
        });

        modelBuilder.Entity<VProdCat>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("v_prod_cat");

            entity.Property(e => e.CategoryId).HasColumnName("category_id");
            entity.Property(e => e.CategoryName)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("category_name");
            entity.Property(e => e.CtegoryDescr)
                .HasMaxLength(300)
                .HasColumnName("ctegory_descr");
            entity.Property(e => e.ProductDescr)
                .HasMaxLength(300)
                .HasColumnName("product_descr");
            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.ProductName)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("product_name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
