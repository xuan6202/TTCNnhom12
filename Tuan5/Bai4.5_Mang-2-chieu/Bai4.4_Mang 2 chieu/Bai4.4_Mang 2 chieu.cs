using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace randomMang2Chieu
{

    class program
    {
        static void Main(string[] args)
        {
            string strhang;
            string strcot;
            int hang;
            int cot;

        nhapsohang:

            Console.Write("Moi ban nhap vao so Hang:");
            strhang = Console.ReadLine();
            if (int.TryParse(strhang, out hang) == true)
            {
            }
            else
            {
                Console.WriteLine("Du lieu ban nhap sai, xin moi nhap lai:");
                goto nhapsohang;
            }
        nhapsocot:

            Console.Write("Moi ban nhap so cot:");
            strcot = Console.ReadLine();
            if (int.TryParse(strcot, out cot) == true)
            {

            }
            else
            {
                Console.WriteLine("Du lieu ban nhap sai, xin moi nhap lai:");
                goto nhapsocot;
            }

            Console.WriteLine("------------------------------------\nSo hang cua mang la: {0}\nSo cot cua mang la:{1}\n------------------------------------\n", hang, cot );


            int[,] Array = new int[hang, cot];

            int sum = 0;


            for (int i = 0; i < Array.GetLength(0); i ++)
            {

                for (int j = 0; j < Array.GetLength(1); j++)
                {
                    Console.Write("Moi ban nhap vao gia tri Array[{0}][{1}]:", i, j);
                    Array[i, j] = int.Parse(Console.ReadLine());
                    sum = sum + Array[i, j];

                }

            }

            Console.WriteLine("\n------------------------------------\nTong gia tri cua mang la: " + sum);


            Console.ReadLine();
        }

    }
}