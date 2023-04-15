using System;

namespace MaTranChuyenVi 
{
    class TestCsharp
    {
        public static void Main()
        {

            int i, j, r, c;
            int[,] arr1 = new int[50, 50];
            int[,] ma_tran_chuyen_vi = new int[50, 50];

            Console.Write("\nTim ma tran chuyen vi trong C#:\n");
            Console.Write("--------------------------------\n");

            Console.Write("\nNhap so hang va so cot cua ma tran ban dau:\n");
            Console.Write("Nhap so hang: ");
            r = Convert.ToInt32(Console.ReadLine());
            Console.Write("Nhap so cot: ");
            c = Convert.ToInt32(Console.ReadLine());

            Console.Write("Nhap cac phan tu cua ma tran:\n");
            for (i = 0; i < r; i++)
            {
                for (j = 0; j < c; j++)
                {
                    Console.Write("Phan tu - [{0}],[{1}]: ", i, j);
                    arr1[i, j] = Convert.ToInt32(Console.ReadLine());
                }
            }

            Console.Write("\nIn ma tran ban dau:\n");
            for (i = 0; i < r; i++)
            {
                Console.Write("\n");
                for (j = 0; j < c; j++)
                    Console.Write("{0}\t", arr1[i, j]);
            }
            //tim ma tran chuyen vi
            for (i = 0; i < r; i++)
            {
                for (j = 0; j < c; j++)
                {

                    ma_tran_chuyen_vi[j, i] = arr1[i, j];
                }
            }

            Console.Write("\n\nIn ma tran chuyen vi: ");
            for (i = 0; i < c; i++)
            {
                Console.Write("\n");
                for (j = 0; j < r; j++)
                {
                    Console.Write("{0}\t", ma_tran_chuyen_vi[i, j]);
                }
            }
            Console.Write("\n\n");

            Console.ReadKey();
        }
    }
}
