using System;

namespace Kiemtrasohoanhao
{
    class Program
    {
        static void Main(string[] args)
        {
            int n, i, sum;

            Console.Write("\n");
            Console.Write("Kiem tra so hoan hoa trong C#:\n");
            Console.Write("------------------------------");
            Console.Write("\n\n");

            Console.Write("Nhap mot so bat ky: ");
            n = Convert.ToInt32(Console.ReadLine());
            sum = 0;
            Console.Write("Cac uoc so duong cua so da cho: ");
            for (i = 1; i < n; i++)
            {
                if (n % i == 0)
                {
                    sum = sum + i;
                    Console.Write("{0}  ", i);
                }
            }
            Console.Write("\nTong cua cac uoc so: {0}", sum);
            if (sum == n)
                Console.Write("\nSo da cho la so hoan hao.");
            else
                Console.Write("\nSo da cho khong phai la so hoan hao.");
            Console.Write("\n");

            Console.ReadKey();
        }
    }
}
