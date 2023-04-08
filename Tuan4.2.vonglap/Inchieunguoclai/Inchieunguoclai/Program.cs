using System;

namespace Inchieunguoclai
{
    class Program
    {
        static void Main(string[] args)
        {
            int num, r, sum = 0, t;

            Console.Write("\n");
            Console.Write("In so theo chieu dao nguoc trong C#:\n");
            Console.Write("-----------------------------------");
            Console.Write("\n\n");


            Console.Write("Nhap mot so bat ky: ");
            num = Convert.ToInt32(Console.ReadLine());

            for (t = num; t != 0; t = t / 10)
            {
                r = t % 10;
                sum = sum * 10 + r;
            }
            Console.Write("So theo chieu dao nguoc cua so da cho la: {0} \n", sum);

            Console.ReadKey();
        }
    }
}
