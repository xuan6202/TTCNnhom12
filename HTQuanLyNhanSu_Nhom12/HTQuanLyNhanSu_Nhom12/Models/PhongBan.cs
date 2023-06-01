using System;
using System.Collections.Generic;

#nullable disable

namespace HTQuanLyNhanSu_Nhom12.Models
{
    public partial class PhongBan
    {
        public PhongBan()
        {
            NhanViens = new HashSet<NhanVien>();
        }

        public string MaPb { get; set; }
        public string TenPb { get; set; }
        public int? SoNvPb { get; set; }
        public string MoTaPb { get; set; }

        public virtual ICollection<NhanVien> NhanViens { get; set; }
    }
}
