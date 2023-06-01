using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace HTQuanLyNhanSu_Nhom12.Models
{
    public partial class QuanLNSContext : DbContext
    {
        public QuanLNSContext()
        {
        }

        public QuanLNSContext(DbContextOptions<QuanLNSContext> options)
            : base(options)
        {
        }

        public virtual DbSet<DangNhap> DangNhaps { get; set; }
        public virtual DbSet<DuAn> DuAns { get; set; }
        public virtual DbSet<NhanVien> NhanViens { get; set; }
        public virtual DbSet<PhongBan> PhongBans { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=LAPTOP-9EGVSH44\\SQLEXPRESS;Initial Catalog=QuanLNS;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<DangNhap>(entity =>
            {
                entity.HasKey(e => e.MaNv)
                    .HasName("PK__DangNhap__2725D70A2E912558");

                entity.ToTable("DangNhap");

                entity.Property(e => e.MaNv)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("MaNV")
                    .IsFixedLength(true);

                entity.Property(e => e.MatKhau)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.TenDn)
                    .HasMaxLength(30)
                    .HasColumnName("TenDN");
            });

            modelBuilder.Entity<DuAn>(entity =>
            {
                entity.HasKey(e => e.MaDa)
                    .HasName("PK__DuAn__2725867A510BEE0A");

                entity.ToTable("DuAn");

                entity.Property(e => e.MaDa)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("MaDA")
                    .IsFixedLength(true);

                entity.Property(e => e.MoTaDa)
                    .HasMaxLength(50)
                    .HasColumnName("MoTa_DA");

                entity.Property(e => e.SoNvDa).HasColumnName("SoNV_DA");

                entity.Property(e => e.TenDa)
                    .HasMaxLength(30)
                    .HasColumnName("TenDA");
            });

            modelBuilder.Entity<NhanVien>(entity =>
            {
                entity.HasKey(e => e.MaNv)
                    .HasName("PK__NhanVien__2725D70A227400E5");

                entity.ToTable("NhanVien");

                entity.Property(e => e.MaNv)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("MaNV")
                    .IsFixedLength(true);

                entity.Property(e => e.DiaChi).HasMaxLength(30);

                entity.Property(e => e.MaDa)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("MaDA")
                    .IsFixedLength(true);

                entity.Property(e => e.MaPb)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("MaPB")
                    .IsFixedLength(true);

                entity.Property(e => e.NgaySinh).HasMaxLength(30);

                entity.Property(e => e.TenNv)
                    .HasMaxLength(30)
                    .HasColumnName("TenNV");

                entity.HasOne(d => d.MaDaNavigation)
                    .WithMany(p => p.NhanViens)
                    .HasForeignKey(d => d.MaDa)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("fk_da");

                entity.HasOne(d => d.MaPbNavigation)
                    .WithMany(p => p.NhanViens)
                    .HasForeignKey(d => d.MaPb)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("fk_pb");
            });

            modelBuilder.Entity<PhongBan>(entity =>
            {
                entity.HasKey(e => e.MaPb)
                    .HasName("PK__PhongBan__2725E7E4A357C9BC");

                entity.ToTable("PhongBan");

                entity.Property(e => e.MaPb)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("MaPB")
                    .IsFixedLength(true);

                entity.Property(e => e.MoTaPb)
                    .HasMaxLength(50)
                    .HasColumnName("MoTaPB");

                entity.Property(e => e.SoNvPb).HasColumnName("SoNV_PB");

                entity.Property(e => e.TenPb)
                    .HasMaxLength(30)
                    .HasColumnName("TenPB");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
