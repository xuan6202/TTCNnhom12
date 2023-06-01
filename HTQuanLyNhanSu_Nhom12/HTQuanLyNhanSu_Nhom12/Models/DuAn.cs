using System;
using System.Collections.Generic;

#nullable disable

namespace HTQuanLyNhanSu_Nhom12.Models
{
    public partial class DuAn
    {
        public DuAn()
        {
            NhanViens = new HashSet<NhanVien>();
        }

        public string MaDa { get; set; }
        public string TenDa { get; set; }
        public int? SoNvDa { get; set; }
        public string MoTaDa { get; set; }

        public virtual ICollection<NhanVien> NhanViens { get; set; }
    }
}
