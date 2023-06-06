using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace WpfApp1.Models
{
    public partial class qlbanhangContext : DbContext
    {
        public qlbanhangContext()
        {
        }

        public qlbanhangContext(DbContextOptions<qlbanhangContext> options)
            : base(options)
        {
        }

        public virtual DbSet<LoaiSanPham> LoaiSanPhams { get; set; }
        public virtual DbSet<SanPham> SanPhams { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=LAPTOP-9EGVSH44\\SQLEXPRESS;Initial Catalog=qlbanhang;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<LoaiSanPham>(entity =>
            {
                entity.HasKey(e => e.MaLoai);

                entity.ToTable("LoaiSanPham");

                entity.Property(e => e.MaLoai)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.TenLoai).HasMaxLength(50);
            });

            modelBuilder.Entity<SanPham>(entity =>
            {
                entity.HasKey(e => e.MaSp);

                entity.ToTable("SanPham");

                entity.Property(e => e.MaSp)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("MaSP")
                    .IsFixedLength(true);

                entity.Property(e => e.MaLoai)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.TenSp)
                    .HasMaxLength(50)
                    .HasColumnName("TenSP");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
