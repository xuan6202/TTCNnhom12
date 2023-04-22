using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
namespace SapxepNoibot 
{
    class Program
    {
        static void Main(string[] args)
        {
            //khai báo biến count để đếm số lần lặp khi sắp xếp
            int count = 0, n;
            //nhập vào số lượng phần tử của mảng, nếu <= 0 thì nhập lại
            do
            {
                Console.Write("\nNhap vao so luong phan tu cua mang: ");
                n = int.Parse(Console.ReadLine());
            } while (n <= 0);
            //khai báo mảng intArray
            int[] intArray = new int[n];
            Console.WriteLine("Nhap vao cac phan tu cua mang: ");
            //sử dụng vòng lặp for để nhập các phần tử cho mảng
            for (int i = 0; i < intArray.Length; i++)
            {
                intArray[i] = int.Parse(Console.ReadLine());
            }
            //sử dụng vòng lặp for đẻ lặp qua các phần tử trong mảng
            for (int j = 0; j <= intArray.Length - 2; j++)
            {
                //sử dụng vòng for thứ hai để lặp qua từng cặp phần tử
                //thực hiện so sánh và đổi vị trí cho đúng thứ tự
                for (int i = 0; i <= intArray.Length - 2; i++)
                {
                    count = count + 1;
                    //so sánh hai phần tử kề nhau và đảo vị trí cho đúng thứ tự sắp xếp
                    if (intArray[i] > intArray[i + 1])
                    {
                        int temp = intArray[i + 1];
                        intArray[i + 1] = intArray[i];
                        intArray[i] = temp;
                    }
                }
            }
            Console.Write("Cac phan tu sau khi sap xep:");
            //in các phần tử
            foreach (int item in intArray)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
            //in số vòng lặp trong quá trình sắp xếp
            Console.Write("So vong lap da thuc hien:" + count);
            Console.WriteLine("\n----Chuong trinh nay duoc dang tai Freetuts.net----\n");
            Console.ReadLine();
        }
    }
}
