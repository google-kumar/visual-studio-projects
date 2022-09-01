using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFramework_example.Models;


//This EF will work only for the table which has primary key,it wont work if the table doesnt have primary key, Drawback of EF


namespace EntityFramework_example
{
     class program2
    {
        public static Car c = new Car();

        static void Main()
        {
            DisplayCar();
            AddCar();
            DisplayCar();
            DeleteCar();
            DisplayCar();
            UpdateCar();
            DisplayCar();
        }

        private static void UpdateCar()
        {
            using (var db = new eurofinsContext())
            {
                Console.WriteLine("Enter CarID: ");
                int CarID = Convert.ToInt32(Console.ReadLine());
                c = db.Cars.Find(CarID);
                Console.WriteLine("Enter CarName: ");
                c.CarName=Console.ReadLine();
                db.Cars.Update(c);
                db.SaveChanges();
            }
        }

        private static void AddCar() // Since this table doesnt have primary key it wont work, drawback of EF
         {
            using (var db = new eurofinsContext())
            {
                Console.WriteLine("Enter CarID,CarName,CarType: ");
                c.CarId = Console.ReadLine();
                c.CarName = Console.ReadLine();
                c.CarType = Console.ReadLine();
                db.Cars.Add(c);
                db.SaveChanges();
            }
        }

        private static void DeleteCar()
        {
            Console.WriteLine("Enter CarID: ");
            string id=Console.ReadLine();
            using (var db = new eurofinsContext())
            {
                c = db.Cars.Find(id);
                db.Cars.Remove(c);
                db.SaveChanges();
                Console.WriteLine(c.CarName + " is deleted ");
            }
        }
        private static void DisplayCar()
        {
            using (var db = new eurofinsContext())
            {
                foreach (var item in db.Cars)
                    Console.WriteLine(item.CarId + " " + item.CarName + " " + item.CarType);
            }
                
        }
    }
}
