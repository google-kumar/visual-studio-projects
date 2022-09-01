using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Department_Store_Library
{
    public class DB_Operations
    {
        public static Products p = new Products();

        public static Department_Store_Context db = new Department_Store_Context();


        public static void Add_Products()
        {
            Console.WriteLine("\n\nAdd Product:\n");
            using (var db = new Department_Store_Context())
            {
                db.SaveChanges();
                p=new Products();
                Console.WriteLine("Enter Product Name: ");
                p.Product_Name = Console.ReadLine();
                Console.WriteLine("Enter Product Price: ");
                p.Product_Price = float.Parse(Console.ReadLine());
                p.Quantity = 1;
                Console.WriteLine("Enter Product Unit (kg/lit/no): ");
                p.Unit = Console.ReadLine();
                db.Products.Add(p);
                db.SaveChanges();
                Console.WriteLine("\n\nProduct added, Product Id: " + p.Product_Id);
            }
        }

        public static void DisplayProducts()
        {
            Console.WriteLine("\nDisplay Products : ");
            using (var db = new Department_Store_Context())
            {
                
                foreach (var item in db.Products)
                    Console.WriteLine(item.Product_Id + ". " + item.Product_Name + " - " + item.Quantity + " " + item.Unit + " costs " + item.Product_Price);
            }

        }

        public static void UpdateProducts()
        {
            Console.WriteLine("\n\n Updation:\n");
            using (var db = new Department_Store_Context())
            {
                db.SaveChanges();
                Console.WriteLine("Enter Product ID: ");
                int PrdID = Convert.ToInt32(Console.ReadLine());
                p = db.Products.Find(PrdID);
                Console.WriteLine("Enter Product Name: ");
                p.Product_Name = Console.ReadLine();
                Console.WriteLine("Enter Price: ");
                p.Product_Price=float.Parse(Console.ReadLine());
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
            using (var db = new Department_Store_Context())
            {
                db.SaveChanges();
                p = db.Products.Find(id);
                db.Products.Remove(p);
                db.SaveChanges();
                Console.WriteLine("\n\n" + p.Product_Name + " is deleted ");
            }
        }

        public static float Calculate()
        {
            float price = 0;
            using (var db = new Department_Store_Context())
            {
                Console.WriteLine("Enter Product ID: ");
                int PrdID = Convert.ToInt32(Console.ReadLine());
                p = db.Products.Find(PrdID);
                if (p != null)
                {
                    Console.WriteLine("Enter Product Quantity: ");
                    int quantity = Convert.ToInt32(Console.ReadLine());
                    price = p.Quantity * p.Product_Price * quantity;
                    return price;
                }
                else
                    Console.WriteLine("\n\nNo product found for the Product ID");
                return 0;
            }
        }
    }
}
