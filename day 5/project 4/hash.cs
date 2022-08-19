using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_4
{
    internal class hash
    {

        public static void Main()
        {
            Hashtable ht = new Hashtable();
            ht.Add("1001","TCS");
            ht.Add("1002", null);
            ht.Add("1003","infy");
           
            foreach (var item in ht.Keys)
            { 
              Console.WriteLine(item);
            }
            foreach (var item in ht.Values)
            {
                Console.WriteLine(item);
            }
            foreach (DictionaryEntry de in ht)
            { 
               Console.WriteLine(de.Key +" "+de.Value);
            
            }
            Console.WriteLine("enter the key to be searched");
            string search=Console.ReadLine();
            if (ht.Contains(search))
            {
                Console.WriteLine(ht[search]);
            }



            Hashtable emps = new Hashtable();
            emps.Add("1001",new emp(1,"Ram"));
            emps.Add("1002", new emp(2, "Raman"));
            emps.Add("1003", new emp());
            
            foreach (emp item in emps.Values)
            {
                Console.WriteLine(item.Eid + " "+item.Ename);
            }

            foreach (var item in emps.Values)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }
}
