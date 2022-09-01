using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace Code_first_EF
{
    class HospitalContext : DbContext
    {
        private const string connectionString = "Server=(localdb)\\mssqllocaldb;Database=HospitalDB;Trusted_Connection=True;";
        public HospitalContext() { }
        public HospitalContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }

        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }

    }
}


//namespace Code_first_EF
//{
//    class HospitalContext : DbContext
//    {
//        private const string connectionString = "Server=.;Database=eurofins;Trusted_Connection=True;";
//        public HospitalContext() { }
//        public HospitalContext(DbContextOptions options) : base(options)
//        {
//        }
//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            optionsBuilder.UseSqlServer(connectionString);
//        }

//        public DbSet<Doctor> Doctors { get; set; }
//        public DbSet<Patient> Patients { get; set; }

//    }
//}
