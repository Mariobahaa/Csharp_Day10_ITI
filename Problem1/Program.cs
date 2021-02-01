using System;
using System.Collections.Generic;
using System.Linq;
using static L2O___D09.ListGenerators;

namespace Problem1
{

    /*
      CustomerList;
      ProductList;
      */
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("LINQ - Restriction Operators");
            //1- Products out of stock
            var res = ProductList.Where(P => P.UnitsInStock == 0);
            Console.WriteLine("1-Products out of Stock:");
            foreach (var p in res)
            {
                Console.WriteLine($"{p}");
            }
            Console.WriteLine("\n");

            //2- Products out of stock and cost more than 3 per unit
            res = ProductList.Where(P => P.UnitsInStock == 0 && P.UnitPrice>3.00m);
            Console.WriteLine("2- Products out of stock and cost more than 3 per unit");
            foreach (var p in res)
            {
                Console.WriteLine($"{p}");
            }
            Console.WriteLine("\n");

            //3- Names of digits whose name is shorter than their values
            string[] Arr = 
            { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

            var dig = Arr.Where((D,i)=> D.Length <i);
            Console.WriteLine("3- Names of digits whose name is shorter than their values");
            foreach (var d in dig)
            {
                Console.Write($"{d}, ");
            }
            Console.WriteLine("\n");

            Console.WriteLine("LINQ - Element Operators");

            var first = ProductList.First(P => P.UnitsInStock == 0);
            Console.WriteLine("1- first Product out of stock");
            Console.WriteLine($"{first}");
            Console.WriteLine("\n");

            first = ProductList.FirstOrDefault(P => P.UnitPrice >1000);
            Console.WriteLine("2- first product whose Price > 1000");
            if (first == null) Console.WriteLine("Not Found");
            else Console.WriteLine($"{first}");
            Console.WriteLine("\n");

            Console.WriteLine("3- second number greater than 5");
            int[] Arr2 = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            var gn = Arr2.Where(D => D > 5).ElementAt(1);
            Console.WriteLine($"{gn}");
            Console.WriteLine("\n");
        }
    }
}
