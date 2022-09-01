using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Department_Store_Library.Models;

namespace Department_Store_Library
{
    public class DB_Operations
    {
        public static Product p = new Product();

        public static Department_StoreContext db = new Department_StoreContext();


        public static void Add_Products()
        {
            Console.WriteLine("\n\nAdd Product:\n");
            using (var db = new Department_StoreContext())
            {
                db.SaveChanges();
                p = new Product();
                Console.WriteLine("Enter Product Name: ");
                p.ProductName = Console.ReadLine();
                Console.WriteLine("Enter Product Price: ");
                p.ProductPrice = float.Parse(Console.ReadLine());
                p.Quantity = 1;
                Console.WriteLine("Enter Product Unit (kg/lit/no): ");
                p.Unit = Console.ReadLine();
                db.Products.Add(p);
                db.SaveChanges();
                Console.WriteLine("\n\nProduct added, Product Id: " + p.ProductId);
            }
        }

        public static void DisplayProducts()
        {
            Console.WriteLine("\nDisplay Products : ");
            using (var db = new Department_StoreContext())
            {

                foreach (var item in db.Products)
                    Console.WriteLine(item.ProductId + ". " + item.ProductName + " - " + item.Quantity + " " + item.Unit + " costs " + item.ProductPrice);
            }

        }

        public static void UpdateProducts()
        {
            Console.WriteLine("\n\n Updation:\n");
            using (var db = new Department_StoreContext())
            {
                db.SaveChanges();
                Console.WriteLine("Enter Product ID: ");
                int PrdID = Convert.ToInt32(Console.ReadLine());
                p = db.Products.Find(PrdID);
                Console.WriteLine("Enter Product Name: ");
                p.ProductName = Console.ReadLine();
                Console.WriteLine("Enter Price: ");
                p.ProductPrice = float.Parse(Console.ReadLine());
                Console.WriteLine("Enter Unit: ");
                p.Unit = Console.ReadLine();
                db.Products.Update(p);
                db.SaveChanges();
                Console.WriteLine("\n\nProduct Updated");
            }
        }

        public static void DeleteProduct()
        {
            Console.WriteLine("\n\n Delete Product:\n");
            Console.WriteLine("Enter Product ID: ");
            int id = Convert.ToInt32(Console.ReadLine());
            using (var db = new Department_StoreContext())
            {
                db.SaveChanges();
                p = db.Products.Find(id);
                db.Products.Remove(p);
                db.SaveChanges();
                Console.WriteLine("\n\n" + p.ProductName + " is deleted ");
            }
        }

        public static float Calculate()
        {
            float price = 0;
            using (var db = new Department_StoreContext())
            {
                Console.WriteLine("Enter Product ID: ");
                int PrdID = Convert.ToInt32(Console.ReadLine());
                p = db.Products.Find(PrdID);
                if (p != null)
                {
                    Console.WriteLine("Enter Product Quantity: ");
                    int quantity = Convert.ToInt32(Console.ReadLine());
                    price = (float)(p.Quantity * p.ProductPrice * quantity);
                    return price;
                }
                else
                    Console.WriteLine("\n\nNo product found for the Product ID");
                return 0;
            }
        }
    }
}
