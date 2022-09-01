using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Department_Store_Library
{
    public class Department_Store_Context : DbContext
    {
        private const string connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=Department_Store;Trusted_Connection=True;";
        public Department_Store_Context() { }
        public Department_Store_Context(DbContextOptions options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }

        public DbSet<Products> Products { get; set; }
    }
}
