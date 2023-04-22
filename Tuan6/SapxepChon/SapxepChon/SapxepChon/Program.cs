﻿using System;
namespace SapxepChon 
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Selection Sort";
            var numbers = new[] { 10, 3, 1, 7, 9, 2, 0 };
            Sort(numbers);
            Console.ReadKey();
        }
        static void Swap<T>(T[] array, int i, int m)
        {
            T temp = array[i];
            array[i] = array[m];
            array[m] = temp;
        }
        static void Print<T>(T[] array)
        {
            Console.WriteLine(string.Join("\t", array));
        }
        static void Sort<T>(T[] array) where T : IComparable
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                int m = i;
                T minValue = array[i];
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[j].CompareTo(minValue) < 0)
                    {
                        m = j;
                        minValue = array[j];
                    }
                }
                Swap(array, i, m);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"Step {i + 1}: i = {i}, m = {m}, min = {minValue}");
                Console.ResetColor();
                Print(array);
                Console.WriteLine();
            }
        }
    }
}
