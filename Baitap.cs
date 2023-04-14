using System;
using System.Linq;

namespace Tuan4
{
    class test{
        public static void Main(){
            int[]arr1= new int[100];
            int i , mx, mn, n;
            Console.Write("\nTim phan tu lon nhat, phan tu nho nhat: \n");
            Console.Write("--------------------------------------\n");
            Console.Write("Nhap so phan tu can luu trong mang: ");
            n = Convert.ToInt32(Console.ReadLine());
            Console.Write("Nhap {0} phan tu vao trong mang: \n", n);
            for(int i=0; i<n;i++){
                Console.Write("Phan tu - {0}: ",i);
                arr1[i]=Convert.ToInt32(Console.ReadLine());
            }
            mx=arr1[0];
            mn=arr1[0];
            for( i=1; i<n; i++){
                if(arr1[i]>mx){
                    mx=arr1[i];
                }
                if(arr1[i]<mn){
                    mn=arr1[i];
                }
            }
            Console.Write("Phan tu lon nhat trong mang la: {0}\n",mx);
            Console.Write("Phan tu nho nhat trong mang la: {0}\n",mn);
            Console.ReadKey();
        }
    }

    
}