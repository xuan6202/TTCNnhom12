using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Tuan4._1
{
    class Program
    {
        static void nhap(int[] a, int n)
        { 
            for (int i = 0; i < n; i++)
            {
                Console.Write("a[" + i + "]=");
                a[i] = int.Parse(Console.ReadLine());
            }
        }
        static void xuat(int[] a, int n)
        {
            Console.Write("Hien thi mang: ");
            for (int i = 0; i < n; i++)
                Console.Write(a[i]+" ");
        }
        static void sxtang(int[] a, int n)
        {
            Console.Write("\nIn cac phan tu theo mang tang dan: \n");
            for (int i = 0; i < n; i++) {
                for(int j = i + 1; j < n; j++)
                {
                    if (a[j] < a[i])
                    {
                        int tg = a[j];
                        a[j] = a[i];
                        a[i] = tg;
                    }
                }
            }
        for(int i = 0; i < n; i++)
            {
                Console.Write("{0}\t", a[i]);
            }   
        }
        static void xoa(int[] a, int n)
        {
            int vtrixoa;
            Console.Write("\nNhap vi tri can xoa: ");
            vtrixoa = Convert.ToInt32(Console.ReadLine());
            //xac dinh vi tri can cua i trong mang
            int i = 0;
            while (i != vtrixoa - 1) 
                i++;
            //vi tri i trong mang se duoc thay the boi gia tri ben phai cua no
            while (i < n)
            {
                a[i] = a[i + 1];
                i++;
            }
            n--;
            Console.Write("\nIn mang sau khi da xoa phan tu: ");
            for(i = 0; i < n; i++)
            {
                Console.Write("{0}\t", a[i]);
            }
        }
        static void Main(string[] args)
        {
            Console.Write("Nhap so ptu cua mang: ");
            int n = int.Parse(Console.ReadLine());
            int[] a = new int[n];
            
            nhap(a, n);
            xuat(a, n);
            sxtang(a, n);
            xoa(a, n);
        }
    }
}
