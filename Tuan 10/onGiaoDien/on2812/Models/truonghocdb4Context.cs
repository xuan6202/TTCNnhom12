﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace on2812.Models
{
    public partial class truonghocdb4Context : DbContext
    {
        public truonghocdb4Context()
        {
        }

        public truonghocdb4Context(DbContextOptions<truonghocdb4Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Lophoc> Lophocs { get; set; }
        public virtual DbSet<Sinhvien> Sinhviens { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=LAPTOP-9EGVSH44\\SQLEXPRESS;Initial Catalog=truonghocdb4;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Lophoc>(entity =>
            {
                entity.HasKey(e => e.Malop)
                    .HasName("PK__lophoc__15F456FDCCEF70A0");

                entity.ToTable("lophoc");

                entity.Property(e => e.Malop).HasColumnName("malop");

                entity.Property(e => e.Giangvien)
                    .HasMaxLength(20)
                    .HasColumnName("giangvien");

                entity.Property(e => e.Tenlop)
                    .HasMaxLength(30)
                    .HasColumnName("tenlop");
            });

            modelBuilder.Entity<Sinhvien>(entity =>
            {
                entity.HasKey(e => e.Masv)
                    .HasName("PK__sinhvien__7A21767C74BFC24E");

                entity.ToTable("sinhvien");

                entity.Property(e => e.Masv)
                    .ValueGeneratedNever()
                    .HasColumnName("masv");

                entity.Property(e => e.Anh)
                    .HasMaxLength(255)
                    .HasColumnName("anh");

                entity.Property(e => e.Diachi)
                    .HasMaxLength(30)
                    .HasColumnName("diachi");

                entity.Property(e => e.Diem).HasColumnName("diem");

                entity.Property(e => e.Hoten)
                    .HasMaxLength(30)
                    .HasColumnName("hoten");

                entity.Property(e => e.Malop).HasColumnName("malop");

                entity.HasOne(d => d.MalopNavigation)
                    .WithMany(p => p.Sinhviens)
                    .HasForeignKey(d => d.Malop)
                    .HasConstraintName("FK_malop");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
