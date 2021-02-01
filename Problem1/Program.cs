﻿using System;
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
            res = ProductList.Where(P => P.UnitsInStock > 0 && P.UnitPrice>3.00m);
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

            /*-------------------------------------------------------------------*/
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


            /*-------------------------------------------------------------------*/
            Console.WriteLine("LINQ - Partitioning Operators");
            //1- 3 orders from customers in Washington
            var cw = CustomerList.Where(C => C.City == "Washington").Take(3);
            Console.WriteLine("1- 3 orders from customers in Washington");
            foreach (var c in cw)
            {
                Console.WriteLine($"{c}");
            }
            Console.WriteLine("\n");

            //2- all but the first 2 orders from customers in Washington
            cw = CustomerList.Where(C => C.City == "Washington").Skip(2);
            Console.WriteLine("2- all but the first 2 orders from customers in Washington");
            foreach (var c in cw)
            {
                Console.WriteLine($"{c}");
            }
            Console.WriteLine("\n");

            //3- elements starting from the beginning 
            //of the array until a number is hit that is less than its position in the array.

            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            var nums = numbers.TakeWhile((N,i) => N>=i);
            Console.WriteLine("3-numbers until a number is hit that is less than its position in the array");
            foreach (var n in nums)
            {
                Console.Write($"{n}, ");
            }
            Console.WriteLine("\n");


            //4- elements of the array starting from the first element divisible by 3.


            nums = numbers.SkipWhile(N => N%3!=0);
            Console.WriteLine("4- elements of the array starting from the first element divisible by 3");
            foreach (var n in nums)
            {
                Console.Write($"{n}, ");
            }
            Console.WriteLine("\n");


            //5- elements of the array starting from the first element less than its position.


            nums = numbers.SkipWhile((N,i) => N>=i);
            Console.WriteLine("5- elements of the array starting from the first element less than its position.");
            foreach (var n in nums)
            {
                Console.Write($"{n}, ");
            }
            Console.WriteLine("\n");


        }



    }
}
