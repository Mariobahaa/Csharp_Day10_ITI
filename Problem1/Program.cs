using System;
using System.Collections.Generic;
using System.Linq;
using static L2O___D09.ListGenerators;
using System.IO;

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

            //2- Products in of stock and cost more than 3 per unit
            res = ProductList.Where(P => P.UnitsInStock > 0 && P.UnitPrice > 3.00m);
            Console.WriteLine("2- Products out of stock and cost more than 3 per unit");
            foreach (var p in res)
            {
                Console.WriteLine($"{p}");
            }
            Console.WriteLine("\n");

            //3- Names of digits whose name is shorter than their values
            string[] Arr =
            { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

            var dig = Arr.Where((D, i) => D.Length < i);
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

            first = ProductList.FirstOrDefault(P => P.UnitPrice > 1000);
            Console.WriteLine("2- first product whose Price > 1000");
            if (first == null) Console.WriteLine("NULL");
            else Console.WriteLine($"{first}");
            Console.WriteLine("\n");

            Console.WriteLine("3- second number greater than 5");
            int[] Arr2 = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            var gn = Arr2.Where(D => D > 5).ElementAt(1);
            Console.WriteLine($"{gn}");
            Console.WriteLine("\n");


            /*-------------------------------------------------------------------*/
            Console.WriteLine("LINQ - Partitioning Operators");
            //1- 3 orders from customers in London
            var cw = CustomerList.Where(C => C.City == "London").Take(3);
            Console.WriteLine("1- 3 orders from customers in London");
            foreach (var c in cw)
            {
                Console.WriteLine($"{c}");
            }
            Console.WriteLine("\n");

            //2- all but the first 2 orders from customers in Washington
            cw = CustomerList.Where(C => C.City == "London").Skip(2);
            Console.WriteLine("2- all but the first 2 orders from customers in Washington");
            foreach (var c in cw)
            {
                Console.WriteLine($"{c}");
            }
            Console.WriteLine("\n");

            //3- elements starting from the beginning 
            //of the array until a number is hit that is less than its position in the array.

            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            var nums = numbers.TakeWhile((N, i) => N >= i);
            Console.WriteLine("3-numbers until a number is hit that is less than its position in the array");
            foreach (var n in nums)
            {
                Console.Write($"{n}, ");
            }
            Console.WriteLine("\n");


            //4- elements of the array starting from the first element divisible by 3.


            nums = numbers.SkipWhile(N => N % 3 != 0);
            Console.WriteLine("4- elements of the array starting from the first element divisible by 3");
            foreach (var n in nums)
            {
                Console.Write($"{n}, ");
            }
            Console.WriteLine("\n");


            //5- elements of the array starting from the first element less than its position.


            nums = numbers.SkipWhile((N, i) => N >= i);
            Console.WriteLine("5- elements of the array starting from the first element less than its position.");
            foreach (var n in nums)
            {
                Console.Write($"{n}, ");
            }
            Console.WriteLine("\n");

            /*-------------------------------------------------------------------*/

            Console.WriteLine("LINQ - Set Operators");

            //1
            var catnms = ProductList.Select(P => P.Category).Distinct();
            foreach (var item in catnms)
                Console.WriteLine($"{item}");

            Console.WriteLine("\n");

            //2
            var prodf = ProductList.Select(P => P.Category[0]);
            var custf = CustomerList.Select(C => C.CustomerID[0]);
            var firsts = prodf.Union(custf);

            foreach (var item in firsts)
                Console.WriteLine($"{item}");

            Console.WriteLine("\n");

            //3 
            firsts = custf.Intersect(prodf);

            foreach (var item in firsts)
                Console.WriteLine($"{item}");

            Console.WriteLine("\n");

            //4
            firsts = prodf.Except(custf);

            foreach (var item in firsts)
                Console.WriteLine($"{item}");

            Console.WriteLine("\n");

            //5
            var prodlst = ProductList.
                Select(P => (P.ProductName.Substring(P.ProductName.Length - 3)));
            var custlst = CustomerList
                .Select(C => ((C.CustomerID.Substring(C.CustomerID.Length - 3))));

            var threes = prodlst.Concat(custlst);

            foreach (var item in threes)
                Console.WriteLine($"{item}");

            Console.WriteLine("\n");

            //LINQ - Aggregate Operators
            Console.WriteLine("LINQ - Aggregate Operators");
            //1
            int[] Arr3 = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            var oddcnt = Arr3.Count(N => N % 2 != 1);
            Console.WriteLine(oddcnt);
            Console.WriteLine("\n");

            //2
            var custord = CustomerList.Select(C => new { customer = C, orders = C.Orders.Count() });

            foreach (var item in custord)
                Console.WriteLine($"{item}");

            Console.WriteLine("\n");

            //3 
            var catg = ProductList.GroupBy(P => P.Category);
            var cnt = catg.Select(C => new { category = C.Key, count = C.Count() }) ;
            foreach (var item in cnt)
                Console.WriteLine($"{item}");

            Console.WriteLine("\n");

            //4
            int[] Arr4 = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            var sm = Arr4.Sum();
            Console.WriteLine($"{sm}");
            Console.WriteLine("\n");

            //5
            string[] dict_en = System.IO.File.ReadAllLines("dictionary_english.txt");

            var ccnt = dict_en.Select(W => W.Count()).Sum();

            Console.WriteLine($"{ccnt}");
            Console.WriteLine("\n");

            //6
            var su = ProductList.Sum(P => P.UnitsInStock);
            Console.WriteLine($"{su}");
            Console.WriteLine("\n");


            //7
            var shortest = dict_en.Min(W => W.Count());

            Console.WriteLine($"{shortest}");
            Console.WriteLine("\n");

            //8
            var cheap = catg.Select(C => C.Min(P => P.UnitPrice));
            foreach(var c in cheap)
            {
                Console.WriteLine(c);
            }
            Console.WriteLine("\n");

            //9

            //var Result = (from P in ProductList
            //              let 
            //              where P.UnitPrice == (ProductList.Min(P => P.UnitPrice))
            //              select P).First();
            //10
            var longest = dict_en.Max(W => W.Count());

            Console.WriteLine($"{longest}");
            Console.WriteLine("\n");

            //11
            var expensive = catg.Select(C => C.Max(P => P.UnitPrice));
            foreach (var c in expensive)
            {
                Console.WriteLine(c);
            }
            Console.WriteLine("\n");

            //12

            //13
            var avg = dict_en.Select(W => W.Count()).Average();

            Console.WriteLine($"{avg}");
            Console.WriteLine("\n");


            //14
            var avgprice = catg.Select(P => P.Average(P => P.UnitPrice));
            foreach (var c in avgprice)
            {
                Console.WriteLine(c);
            }
            Console.WriteLine("\n");

            //LINQ - Quantifiers
            Console.WriteLine("LINQ - Quantifiers");


            //1
            bool hasei = dict_en.Any(W => W.Contains("ei"));
            Console.WriteLine($"{hasei}");
            Console.WriteLine("\n");


            //2
            var oneout = catg.Where(C => C.Any(P => P.UnitsInStock == 0));
            foreach (var c in oneout)
            {
                foreach(var i in c)
                    Console.WriteLine(i);
                Console.WriteLine("######");
            }
            Console.WriteLine("\n");


            //3
            var allin = catg.Where(C => C.All(P => P.UnitsInStock > 0));
            foreach (var c in allin)
            {
                foreach (var i in c)
                    Console.WriteLine(i);
                Console.WriteLine("######");
            }
            Console.WriteLine("\n");

        }



    }
}
