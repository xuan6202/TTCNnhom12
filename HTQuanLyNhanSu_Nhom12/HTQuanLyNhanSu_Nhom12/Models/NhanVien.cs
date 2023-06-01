using System;
using System.Collections.Generic;

#nullable disable

namespace HTQuanLyNhanSu_Nhom12.Models
{
    public partial class NhanVien
    {
        public string MaNv { get; set; }
        public string TenNv { get; set; }
        public string NgaySinh { get; set; }
        public string DiaChi { get; set; }
        public double? Luong { get; set; }
        public string MaPb { get; set; }
        public string MaDa { get; set; }

        public virtual DuAn MaDaNavigation { get; set; }
        public virtual PhongBan MaPbNavigation { get; set; }
    }
}
