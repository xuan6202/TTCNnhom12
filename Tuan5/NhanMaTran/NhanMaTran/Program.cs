using System;

namespace NhanMaTran 
{
    class TestCsharp
    {
        public static void Main()
        {

            int i, j, k, r1, c1, r2, c2, sum = 0;

            int[,] arr1 = new int[50, 50];
            int[,] arr2 = new int[50, 50];
            int[,] ma_tran_tich = new int[50, 50];

            Console.Write("\nNhan hai ma tran trong C#:\n");
            Console.Write("----------------------------------\n");

            Console.Write("\nNhap so hang va so cot cua ma tran thu nhat:\n");
            Console.Write("Nhap so hang: ");
            r1 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Nhap so cot: ");
            c1 = Convert.ToInt32(Console.ReadLine());

            Console.Write("\nNhap so hang va so cot cua ma tran thu hai:\n");
            Console.Write("Nhap so hang: ");
            r2 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Nhap so cot: ");
            c2 = Convert.ToInt32(Console.ReadLine());

            if (c1 != r2)
            {
                Console.Write("Khong the nhan hai ma tran tren !!!");
                Console.Write("\nSo cot cua ma tran thu nhat phai bang so hang cua ma tran thu hai.");
            }
            else
            {
                Console.Write("Nhap cac phan tu cua ma tran thu nhat:\n");
                for (i = 0; i < r1; i++)
                {
                    for (j = 0; j < c1; j++)
                    {
                        Console.Write("Phan tu - [{0}],[{1}]: ", i, j);
                        arr1[i, j] = Convert.ToInt32(Console.ReadLine());
                    }
                }
                Console.Write("Nhap cac phan tu cua ma tran thu hai:\n");
                for (i = 0; i < r2; i++)
                {
                    for (j = 0; j < c2; j++)
                    {
                        Console.Write("Phan tu - [{0}],[{1}]: ", i, j);
                        arr2[i, j] = Convert.ToInt32(Console.ReadLine());
                    }
                }
                Console.Write("\nIn ma tran dau tien:\n");
                for (i = 0; i < r1; i++)
                {
                    Console.Write("\n");
                    for (j = 0; j < c1; j++)
                        Console.Write("{0}\t", arr1[i, j]);
                }

                Console.Write("\nIn ma tran thu hai:\n");
                for (i = 0; i < r2; i++)
                {
                    Console.Write("\n");
                    for (j = 0; j < c2; j++)
                        Console.Write("{0}\t", arr2[i, j]);
                }
                //nhan hai ma tran
                for (i = 0; i < r1; i++)
                    for (j = 0; j < c2; j++)
                        ma_tran_tich[i, j] = 0;
                for (i = 0; i < r1; i++)    //hang cua ma tran thu nhat 
                {
                    for (j = 0; j < c2; j++)    //cot cua ma tran thu hai 
                    {
                        sum = 0;
                        for (k = 0; k < c1; k++)
                            sum = sum + arr1[i, k] * arr2[k, j];
                        ma_tran_tich[i, j] = sum;
                    }
                }
                Console.Write("\nMa tran tich cua hai ma tran tren la: \n");
                for (i = 0; i < r1; i++)
                {
                    Console.Write("\n");
                    for (j = 0; j < c2; j++)
                    {
                        Console.Write("{0}\t", ma_tran_tich[i, j]);
                    }
                }
            }
            Console.Write("\n\n");

            Console.ReadKey();
        }
    }
}
