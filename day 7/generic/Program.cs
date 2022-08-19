using System;
using System.Collections.Generic;
using System.Collections;

namespace generic
{
    internal class Program
    {
        static void Main()
        { 
           ArrayList al=new ArrayList();
            al.Add("1");
            al.Add("visnu");
            foreach (String item in al)
            { 
                Console.WriteLine(item);
            }
           
        
           List<int> l=new List<int>();
            l.Add(1);
            l.Add(2);

            foreach (int item in l)
               Console.WriteLine(item);

            al.Clear();

            Dictionary<int, int> dic=new Dictionary<int, int>();        
            dic.Add(1, 1);
            dic.Add(2, 2);  
            dic.Add(3, 3);
            foreach (KeyValuePair<int, int> item in dic)
            { 
             Console.WriteLine(item.Key+" "+item.Value);
            
            }

            Console.WriteLine("search key");

            int search = Convert.ToInt32(Console.ReadLine());
            if (dic.ContainsKey(search))
                Console.WriteLine(dic[search]);
            else
                Console.WriteLine("not found");

        }
    
    }

}