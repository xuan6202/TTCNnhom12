using System;
using System.Collections.Generic;

namespace SinhVien 
{
    class NGUOI
    {
        public string hoten { get; set; }
        public string diachi { get; set; }
        public int tuoi { get; set; }
        public NGUOI()
        {
            tuoi = 0; hoten = " "; diachi = " ";
        }
        public NGUOI(string ht, int t, string dc)
        {
            hoten = ht;
            diachi = dc;
            tuoi = t;
        }
        public virtual void input()
        {
            // Console.OutputEncoding = Encoding.UTF8;

            Console.Write("Vao ho ten: ");
            hoten = Console.ReadLine();
            Console.Write("Vao tuoi: ");
            tuoi = Int32.Parse(Console.ReadLine());
            Console.Write("Vao dia chi: ");
            diachi = Console.ReadLine();
        }
        public virtual void show()
        {
            Console.Write("{0,-20}{1,-10}{2,-30}", hoten, tuoi, diachi);
        }
    }

    class SINHVIEN : NGUOI
    {
        public double dtb { get; set; }
        public SINHVIEN() : base()
        {
            dtb = 0;
        }
        public SINHVIEN(string ht, int t, string dc, double tb) : base(ht, t, dc)
        {
            dtb = tb;
        }
        public override void input()
        {
            base.input();
            Console.Write("Vao DTB: ");
            dtb = double.Parse(Console.ReadLine());
        }
        public override void show()
        {
            base.show();
            Console.WriteLine("{0,-10}", dtb);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            //constructor ko co ts
            SINHVIEN sv1 = new SINHVIEN();
            sv1.input();
            sv1.show();
            Console.ReadLine();

            //constructor co ts
            SINHVIEN sv2 = new SINHVIEN("Mai", 18, "Ha Noi", 8);
            sv2.show();
            Console.ReadLine();

            //dung list
            List<SINHVIEN> dssv = new List<SINHVIEN>();
            int n;
            Console.Write("Nhap so luong sinh vien: ");
            n = int.Parse(Console.ReadLine());
            Console.WriteLine("\nNHAP DANH SACH SINH VIEN");
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Nhap sinh vien thu {0}: ", i + 1);

                SINHVIEN sv = new SINHVIEN();
                sv.input();
                dssv.Add(sv);
            }
            Console.WriteLine("\nDANH SACH SINH VIEN VUA NHAP LA: ");
            Console.WriteLine("{0,-20}{1,-10}{2,-30}{3,-10}", "Ho ten", "Tuoi", "Dia chi", "Diem TB");
            foreach (SINHVIEN item in dssv)
                item.show();
            Console.ReadLine();
        }
    }
}