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
            Console.WriteLine("P1");
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

        }
    }
}
