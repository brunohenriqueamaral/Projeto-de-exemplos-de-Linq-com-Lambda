﻿using System;
using LinqComLambda.Entities;
using System.Collections.Generic;
using System.Linq;

namespace LinqComLambda
{
    class Program
    {
        static void Print <T> (string message, IEnumerable<T> collection)
        {
            Console.WriteLine(message);
            foreach (T obj in collection)
            {
                Console.WriteLine(obj);
            }
        }
        static void Main(string[] args)
        {
            Category c1 = new Category() { Id = 1, Name = "Tools", Tier = 2 };
            Category c2 = new Category() { Id = 2, Name = "Computer", Tier = 1 };
            Category c3 = new Category() { Id = 3, Name = "Eletronics", Tier = 1 };

            List<Product> products = new List<Product>
            {
                new Product(){Id = 1, Name = "Computer", Price = 1100.0, Category = c2},
                new Product(){Id = 2, Name = "Hammer", Price = 90.0, Category = c1},
                new Product(){Id = 3, Name = "TV", Price = 1700.0, Category = c3},
                new Product(){Id = 4, Name = "Notebook", Price = 1300.0, Category = c2},
                new Product(){Id = 5, Name = "Saw", Price = 80.0, Category = c1},
                new Product(){Id = 6, Name = "Tablet", Price = 700.0, Category = c2},
                new Product(){Id = 7, Name = "Camera", Price = 700.0, Category = c3},
                new Product(){Id = 8, Name = "Printer", Price = 350.0, Category = c3},
                new Product(){Id = 9, Name = "Macbook", Price = 1800.0, Category = c2},
                new Product(){Id = 10, Name = "Sound Bar", Price = 700.0, Category = c3},
                new Product(){Id = 12, Name = "Level", Price = 70.0, Category = c1},
            };

            var r1 = products.Where(p => p.Category.Tier == 1 && p.Price < 900.0);
            Print("TIER 1 AND PRICE < 900: ", r1);
            Console.WriteLine();

            var r2 = products.Where(p => p.Category.Name == "Tools").Select(p => p.Name);
            Print("NAMES OF PRODUCTS FROM TOOLS ", r2);
            Console.WriteLine();

            var r3 = products.Where(p => p.Name[0] == 'C').Select(p => new { p.Name, p.Price, CategoryName = p.Category.Name });
            Print("NAMES STARTED WITH 'C' AND ANONYMOUS OBJECT", r3);
            Console.WriteLine();

            var r4 = products.Where(p => p.Category.Tier == 1).OrderBy(p => p.Price).ThenBy(p => p.Name);
            Print("TIER 1 ORDER BY PRICE THEN BY NAME", r4);
            Console.WriteLine();

            var r5 = r4.Skip(2).Take(4);
            Print("TIER 1 ORDER BY PRICE THAN BY NAME SKIP 2 TAKE 4", r5);
            Console.WriteLine();

            var r6 = products.FirstOrDefault();
            Console.WriteLine("First or default test 1: "+ r6);

            var r7 = products.Where(p => p.Price > 3000.0).FirstOrDefault();
            Console.WriteLine("First or default test 2 : "+ r7);
            Console.WriteLine();

            var r8 = products.Where(p => p.Id == 3).SingleOrDefault();
            Console.WriteLine("SINGLE OR DEFAULT TEST 1 : "+ r8 );

            var r9 = products.Where(p => p.Id == 30).SingleOrDefault();
            Console.WriteLine("SINGLE OR DEFAULT TEST 2 : "+ r9);
            Console.WriteLine();

            var r10 = products.Max(p => p.Price);
            Console.WriteLine("MAX PRICE: "+ r10);

            var r11 = products.Min(p => p.Price);
            Console.WriteLine("Min price: "+ r11);

            var r12 = products.Where(p => p.Category.Id == 1).Sum(p => p.Price);
            Console.WriteLine("Category 1 sum prices: "+ r12);

            var r13 = products.Where(p => p.Category.Id == 1).Average(p => p.Price);
            Console.WriteLine("Category 1 average prices: "+ r13);

            var r14 = products.Where(p => p.Category.Id == 1).Select(p => p.Price).Aggregate((x, y) => x + y);
            Console.WriteLine("Catergory 1 agregate sum: "+ r14);

            Console.WriteLine();

            var r15 = products.GroupBy(p => p.Category);
            foreach (IGrouping<Category, Product> group in r15)
            {

                Console.WriteLine("Grup by category: "+ group.Key.Name+":");
                foreach (Product p in group)
                {
                    Console.WriteLine(p);
                }
                Console.WriteLine();
            }
        }
    }
}
