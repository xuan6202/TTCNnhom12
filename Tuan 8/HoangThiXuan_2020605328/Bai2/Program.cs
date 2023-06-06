using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai2
{
    class PERSON
    {
        public string hoTen { get; set; }
        public string gioiTinh { get; set; }
        public int namSinh { get; set; }

        public PERSON()
        {
            hoTen = ""; gioiTinh = ""; namSinh = 0;
        }
        public PERSON(string ht, string gt, int ns)
        {
            hoTen = ht;
            gioiTinh = gt;
            namSinh = ns;
        }

        public virtual void input()
        {
            Console.Write("Nhap ho ten: ");
            hoTen = Console.ReadLine();
            Console.Write("Nhap gioi tinh: ");
            gioiTinh = Console.ReadLine();
            Console.Write("Nhap nam sinh: ");
            namSinh = int.Parse(Console.ReadLine());
        }

        public virtual void show()
        {
            Console.Write("{0,-20}{1,-10}{2,-10}", hoTen, gioiTinh, namSinh);
        }
    }
    class CONGNHAN : PERSON
    {
        public string tenCT { get; set; }
        public double hsl { get; set; }
        public CONGNHAN() : base()
        {
            tenCT = ""; hsl = 0;
        }

        public CONGNHAN(string ht, string gt, int ns, string ct, double l) : base(ht, gt, ns)
        {
            tenCT = ct;
            hsl = l;
        }

        public override void input()
        {
            base.input();
            Console.Write("Nhap ten cong ty: ");
            tenCT = Console.ReadLine();
            Console.Write("Nhap he so luong: ");
            hsl = double.Parse(Console.ReadLine());
        }

        public override void show()
        {
            base.show();
            Console.WriteLine("{0,-20}{1,20}{2,20}", tenCT, hsl, thuNhap());
        }



        public double thuNhap()
        {
            return hsl * 850000;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            /*//khong sung tham so
            CONGNHAN cn1 = new CONGNHAN();
            cn1.input();
            cn1.show();

            //su dung tham so
            CONGNHAN cn2 = new CONGNHAN("Nhu Quynh", "Nu", 2001, "FPT", 500);
            cn2.show();*/

            //su dung list
            List<CONGNHAN> DSCN = new List<CONGNHAN>();
            int n;
            
            Console.Write("\nNHAP DANH SACH CONG NHAN: ");
            n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Nhap cong nhan thu " + (i + 1));
                CONGNHAN cn = new CONGNHAN();
                cn.input();
                DSCN.Add(cn);
            }
            Console.WriteLine("\nDANH SACH CONG NHAN VUA NHAP LA: ");
            Console.WriteLine("{0,-20}{1,-10}{2,-10}{3,-20}{4,20}{5,20}",
                "Ho ten", "Tuoi", "Nam sinh", "Ten CT", "HSL", "Luong");
            foreach (CONGNHAN item in DSCN)
                item.show();
            Console.WriteLine("\nCONG NHAN CO HE SO LUONG CAO NHAT: ");
            maxHSL(DSCN);
            Console.ReadLine();
        }

        static void maxHSL(List<CONGNHAN> DSCN)
        {
            double max = 0;
            List<CONGNHAN> cn = new List<CONGNHAN>();
            foreach (CONGNHAN item in DSCN)
            {
                if (item.hsl > max)
                    max = item.hsl;

            }
            foreach (CONGNHAN item in DSCN)
            {
                if (item.hsl == max)
                    cn.Add(item);
            }
            foreach (CONGNHAN item in cn)
                item.show();
        }
    }
}
