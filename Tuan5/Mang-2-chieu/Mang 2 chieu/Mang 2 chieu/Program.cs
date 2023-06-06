using System;

namespace LearningCode
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.Title = "Minh Học Code";
        beginInputRows:
            Console.Write("Nhập số dòng: ");
            if (int.TryParse(Console.ReadLine(), out int rows) == false)
            {
                Console.WriteLine("Nhập sai dữ liệu!\n");
                goto beginInputRows;
            }
        beginInputCols:
            Console.Write("Nhập số cột: ");
            if (int.TryParse(Console.ReadLine(), out int cols) == false)
            {
                Console.WriteLine("Nhập sai dữ liệu!\n");
                goto beginInputCols;
            }
            int[,] newInt = new int[rows, cols];
        beginInputArray:
            for (int i = 0; i < newInt.GetLength(0); i++)
            {
                for (int j = 0; j < newInt.GetLength(1); j++)
                {
                    Console.Write("Vui lòng nhập phần tử newInt[{0},{1}]: ", i, j);
                    int checkInt;
                    if (int.TryParse(Console.ReadLine(), out checkInt) == false)
                    {
                        Console.WriteLine("Nhập sai dữ liệu, vui lòng nhập lại!\n");
                        goto beginInputArray;
                    }
                    else
                    {
                        newInt[i, j] = checkInt;
                    }
                }
            }
            Console.Clear();
            Console.WriteLine("Đây là kết quả của bạn");
            int sum = 0;
            for (int i = 0; i < newInt.GetLength(0); i++)
            {
                for (int j = 0; j < newInt.GetLength(1); j++)
                {
                    Console.Write("{0,5}", newInt[i, j]);
                    sum += newInt[i, j];
                }
                Console.WriteLine();
            }
            Console.WriteLine($"Đây là tổng: {sum}");
            Console.ReadKey();
        }
    }
}