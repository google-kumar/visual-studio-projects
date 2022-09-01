using System;
using EntityFramework_example.Models;
namespace EntityFramework_example
{
    class Program
    { 
         public static eurofinsContext db = new eurofinsContext();
        static void main()
        { 
             foreach(var item in db.Cars)
                Console.WriteLine(item.CarId + " " + item.CarName + " " + item.CarType);
        }
    }
}
