using System;
using System.Collections.Generic;

namespace linq
{

    //Language Integrated Query
    //1.Native Query Language
    //2.Data source - any (LINQ to XML,LINQ to entites,LiNQ to SQL,LINQ to collections , LINQ to objects)
    //2 syntax in LINQ - query syntax,method syntax
    class program
    {
        //IQueryable
        static void main(string[] args)
        {

            List<int> numbers = new List<int>();
            numbers.Add(50);
            numbers.Add(100);
            numbers.Add(80);
            numbers.Add(12);
            var result=(from i in numbers
                       where i>45
                       select i).ToList();

            foreach(var item in result)
                Console.WriteLine(item);

            //method syntax
            Console.WriteLine(" method syntax output ");
            var resnumbers = numbers.Where(x => x > 45).Select(x => x);
            foreach(var item in resnumbers)
                Console.WriteLine(item);



            List<string> fruits = new List<string>();
            fruits.Add("Mango");
            fruits.Add("Apricot");
            fruits.Add("Apple");
            var res=(from i in fruits
                where i.StartsWith ('A')
                select  i).ToList();

            foreach(var item in res)
                Console.WriteLine(item);


            //method syntax
            Console.WriteLine(" method syntax output ");
            var resfruits = fruits.Where(a => a.StartsWith('A')).Select(a => a);
            foreach (var item in resfruits)
                Console.WriteLine(item);

        }
    }
}