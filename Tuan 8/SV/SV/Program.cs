using System;
using System.Collections.Generic;
namespace SV
{
class SinhVien
    {
        private string maSV;
        private string hoTen;
        private double diemToan;
        private double diemLy;
        private double diemHoa;

        public SinhVien(string maSV, string hoTen, double diemToan, double diemLy, double diemHoa)
        {
            this.maSV = maSV;
            this.hoTen = hoTen;
            this.diemToan = diemToan;
            this.diemLy = diemLy;
            this.diemHoa = diemHoa;
        }

        public string MaSV
        {
            get { return maSV; }
        }

        public string HoTen
        {
            get { return hoTen; }
        }

        public double DiemTrungBinh
        {
            get { return (diemToan + diemLy + diemHoa) / 3; }
        }
    }

    class QuanLySinhVien
    {
        private List<SinhVien> dsSinhVien = new List<SinhVien>();

        public void ThemSinhVien(SinhVien sv)
        {
            dsSinhVien.Add(sv);
        }

        public void HienThiDanhSachSinhVien()
        {
            Console.WriteLine("{0,-10} {1,-20} {2,-10}", "Ma SV", "Ho Ten", "Diem TB");
            foreach (SinhVien sv in dsSinhVien)
            {
                Console.WriteLine("{0,-10} {1,-20} {2,-10}", sv.MaSV, sv.HoTen, sv.DiemTrungBinh);
            }
        }

        public SinhVien TimSinhVienTheoMa(string maSV)
        {
            foreach (SinhVien sv in dsSinhVien)
            {
                if (sv.MaSV == maSV)
                {
                    return sv;
                }
            }
            return null;
        }

        public double TinhDiemTrungBinhSinhVienTheoMa(string maSV)
        {
            SinhVien sv = TimSinhVienTheoMa(maSV);
            if (sv != null)
            {
                return sv.DiemTrungBinh;
            }
            return -1;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            QuanLySinhVien qlsv = new QuanLySinhVien();
            qlsv.ThemSinhVien(new SinhVien("001", "Nguyen Van A", 6.5, 7, 8));
            qlsv.ThemSinhVien(new SinhVien("002", "Hoang Thi B", 7.5, 8.5, 6.5));
            qlsv.ThemSinhVien(new SinhVien("003", "Tran Van C", 8, 9, 9));
            qlsv.HienThiDanhSachSinhVien();
            Console.WriteLine();
            Console.WriteLine("Diem trung binh cua sinh vien 002: {0}", qlsv.TinhDiemTrungBinhSinhVienTheoMa("002"));
        }
    }
}
