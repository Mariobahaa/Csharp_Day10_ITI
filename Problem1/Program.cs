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
            var cnt = catg.Select(C => new { category = C.Key, count = C.Count() });
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
            foreach (var c in cheap)
            {
                Console.WriteLine(c);
            }
            Console.WriteLine("\n");

            //9

            var chpst = from P in ProductList
                        group P by P.Category into Cat
                        let cheapest = Cat.Min(P => P.UnitPrice)
                        select new { Category = Cat.Key, Cheapest = cheapest };
            foreach (var c in chpst)
            {
                Console.WriteLine(c);
            }
           

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

            var mstexp = from P in ProductList
                        group P by P.Category into Cat
                        let exp = Cat.Max(P => P.UnitPrice)
                        select new { Category = Cat.Key, MostExpensive = exp };
            foreach (var c in mstexp)
            {
                Console.WriteLine(c);
            }

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
                foreach (var i in c)
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

            //LINQ - Grouping Operators
            Console.WriteLine("LINQ - Grouping Operators");


            //1
            var seq = Enumerable.Range(0, 15);
            var grfive = seq.GroupBy(N => N % 5);

            foreach (var c in grfive)
            {
                foreach (var i in c)
                    Console.WriteLine(i);
                Console.WriteLine("######");
            }
            Console.WriteLine("\n");

            //2
            var gfrstlet = dict_en.GroupBy(W => W[0]);


            ///////////UNCOMMENT This Section //////////////////////////////////
/*
            foreach (var c in gfrstlet)
            {
                foreach (var i in c)
                    Console.WriteLine(i);
                Console.WriteLine("######");
            }
            Console.WriteLine("\n");
*/

            //3
            string[] Arr5 = { "from   ", " salt", " earn ", "  last   ", " near ", " form  " };

            WordsComparer WC = new WordsComparer();
            var gwords = Arr5.GroupBy(W => W, WC);

            foreach (var c in gwords)
            {
                foreach (var i in c)
                    Console.WriteLine(i);
                Console.WriteLine("######");
            }
            Console.WriteLine("\n");

            //LINQ - Ordering Operators
            Console.WriteLine("LINQ - Ordering Operators");

            //1
            var srtprods = ProductList.OrderBy(P => P.ProductName);
            foreach (var c in srtprods)
            {
                Console.WriteLine(c);

            }
            Console.WriteLine("\n");

            //2
            string[] Arr6 = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };

            CaseInsensetiveComparer CIC = new CaseInsensetiveComparer();
            var srtwords = Arr6.OrderBy(W => W, CIC);
            foreach (var c in srtwords)
            {
                Console.WriteLine(c);

            }
            Console.WriteLine("\n");

            //3
            var srtpByunits = ProductList.OrderByDescending(P => P.UnitsInStock);
            foreach (var c in srtpByunits)
            {
                Console.WriteLine(c);

            }
            Console.WriteLine("\n");

            //4
            string[] Arr7 = { "zero", "one", "two", "three", "four",
                              "five", "six", "seven", "eight", "nine" };

            var srtdigits = Arr7.OrderBy(D => D.Count()).ThenBy(D => D);

            foreach (var c in srtdigits)
            {
                Console.WriteLine(c);

            }
            Console.WriteLine("\n");

            //5
            string[] words = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };

            var srtwordsBylenCI = words.OrderBy(W => W.Count()).ThenBy(W => W, CIC);

            foreach (var c in srtwordsBylenCI)
            {
                Console.WriteLine(c);

            }
            Console.WriteLine("\n");

            //6

            var srtpBCatPrice = ProductList.OrderBy(P => P.Category).ThenByDescending(P => P.UnitPrice);
            foreach (var c in srtpBCatPrice)
            {
                Console.WriteLine(c);

            }
            Console.WriteLine("\n");

            //7
            var srtwordsByLenCI = words.OrderBy(D => D.Count()).ThenByDescending(D => D, CIC);

            foreach (var c in srtwordsByLenCI)
            {
                Console.WriteLine(c);

            }
            Console.WriteLine("\n");

            //8
            List<String> arr7 = Arr7.ToList();
            var srtI = Arr7.Where(D => D[1] == 'i').OrderByDescending(D => arr7.IndexOf(D));

            foreach (var c in srtI)
            {
                Console.WriteLine(c);

            }
            Console.WriteLine("\n");

            //LINQ - Projection Operators
            Console.WriteLine("LINQ - Projection Operators");

            //1
            var pnames = ProductList.Select(P => P.ProductName);

            foreach (var c in pnames)
            {
                Console.WriteLine(c);
            }
            Console.WriteLine("\n");

            //2
            string[] wordsArr = { "aPPLE", "BlUeBeRrY", "cHeRry" };
            var wordversions = wordsArr.Select(P => new { Upper = P.ToUpper(), Lower = P.ToLower() });

            foreach (var c in wordversions)
            {
                Console.WriteLine(c);
            }
            Console.WriteLine("\n");

            //3
            var prodprops = ProductList.Select(P => new { Price = P.UnitPrice, ID = P.ProductID, Name = P.ProductName });

            foreach (var c in prodprops)
            {
                Console.WriteLine(c);
            }
            Console.WriteLine("\n");

            //4
            int[] Arr8 = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            var valEqInd = Arr8.Select((D, i) => D == i);

            foreach (var c in valEqInd)
            {
                Console.WriteLine(c);
            }
            Console.WriteLine("\n");

            //5
            int[] numbersA = { 0, 2, 4, 5, 6, 8, 9 };
            int[] numbersB = { 1, 3, 5, 7, 8 };

            var pairs = from A in numbersA
                        let B = numbersB
                        from item in B
                        where A < item
                        select A + " is smaller than " + item;

            foreach (var c in pairs)
            {
   
                    Console.WriteLine(c);
            }
            Console.WriteLine("\n");


            //6
            var lessthan500 = CustomerList.SelectMany(C => C.Orders).Where(O => O.Total < 500);
            foreach (var c in lessthan500)
            { 
                    Console.WriteLine(c);
            }
            Console.WriteLine("\n");

            //7
            var after1997 = CustomerList.SelectMany(C => C.Orders).Where(O => O.OrderDate.Year>=1998);
            foreach (var c in after1997)
            {
                Console.WriteLine(c);
            }
            Console.WriteLine("\n");

        }



    }
}
