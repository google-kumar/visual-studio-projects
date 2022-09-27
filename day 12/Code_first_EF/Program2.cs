using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Code_first_EF.Migrations;
using Code_first_EF.Models;
using Microsoft.EntityFrameworkCore;

namespace Code_first_EF
{
    internal class Program2
    {

           public static Doctor d=new Doctor();
           public static Patient p = new Patient(); 
     
            public static HospitalContext db = new HospitalContext();
            public static void Main()
            {
                DisplayDoctors();
                //AddDoctors();
                //DisplayDoctors();
                //UpdateDoctors();
                //DisplayDoctors();
                //DeleteDoctor();
                //DisplayDoctors();

                //DisplayPatients();
                //AddPatients();
                //DisplayPatients();
                //UpdatePatients();
                
                //DisplayPatients();
                //DeletePatient();
                //DisplayPatients();

            }

        private static void AddDoctors() 
        {
            Console.WriteLine("\n\nAdd Doctor:\n");
            using (var db = new HospitalContext())
            {
                Console.WriteLine("Enter DocName,Specialization,Yrs of Exp,seniorID: ");
                d.DocName = Console.ReadLine();
                d.Specialization = Console.ReadLine();
                d.yrsofExp=float.Parse(Console.ReadLine());
                d.SeniorID = Convert.ToInt32(Console.ReadLine());
                db.Doctors.Add(d);
                db.SaveChanges();
                Console.WriteLine("DocId: " + d.DocID);
            }
        }

        private static void DisplayDoctors()
        {
            Console.WriteLine("\nDisplay Doctors : ");
            using (var db = new HospitalContext())
            {
                foreach (var item in db.Doctors)
                    Console.WriteLine(item.DocID + " " + item.DocName + " " + item.Specialization + " " + item.yrsofExp + " " + item.SeniorID);
            }

        }

        private static void UpdateDoctors()
        {
            Console.WriteLine("\n\n Updation:\n");
            using (var db = new HospitalContext())
            {
                Console.WriteLine("Enter DocID: ");
                int DocID = Convert.ToInt32(Console.ReadLine());
                d = db.Doctors.Find(DocID);
                Console.WriteLine("Enter Doctor Name: ");
                d.DocName = Console.ReadLine();
                Console.WriteLine("Specialization: ");
                d.Specialization= Console.ReadLine();
                Console.WriteLine("Years od exp: ");
                d.yrsofExp = float.Parse(Console.ReadLine());
                Console.WriteLine("SeniorID: ");
                d.SeniorID = Convert.ToInt32(Console.ReadLine());
                db.Doctors.Update(d);
                db.SaveChanges();
            }
        }

        private static void DeleteDoctor()
        {
            Console.WriteLine("\n\n Delete doctor:\n");
            Console.WriteLine("Enter DocID: ");
            int id = Convert.ToInt32(Console.ReadLine());
            using (var db = new HospitalContext())
            {
                d = db.Doctors.Find(id);
                db.Doctors.Remove(d);
                db.SaveChanges();
                Console.WriteLine(d.DocName + " is deleted ");
            }
        }

        private static void DisplayPatients()
        {
            Console.WriteLine("\nDisplay Patients : ");
            var result = db.Patients.Include(x=>x.doctor);
            using (var db = new HospitalContext())
            {
                foreach (var item in result)
                    Console.WriteLine(item.PatientID + " " + item.PatientName + " consulted by " + item.doctor.DocName );
            }
        }

        private static void AddPatients()
        {
            Console.WriteLine("\n\nAdd Patient:\n");
            using (var db = new HospitalContext())
            {
                Console.WriteLine("Enter Patient Name and Doctor ID: ");
                p.PatientName = Console.ReadLine();
                int did=Convert.ToInt32(Console.ReadLine());
                d = db.Doctors.Find(did);
                p.doctor = d;
                db.Patients.Add(p);
                db.SaveChanges();
                Console.WriteLine("Patient Id: " + p.PatientID);
            }
        }
        private static void UpdatePatients()
        {
            db.Patients.Include(x => x.doctor);
            Console.WriteLine("\n\n Updation:\n");
            using (var db = new HospitalContext())
            {
              
                Console.WriteLine("Enter Patient ID: ");
                int PatID = Convert.ToInt32(Console.ReadLine());
                p = db.Patients.Find(PatID);
                int did = Find_DocID(PatID);
                d = db.Doctors.Find(did);
                Console.WriteLine("Enter Patient Name: ");
                p.PatientName = Console.ReadLine();
                p.doctor = d;
                db.Patients.Update(p);
                db.SaveChanges();
            }
        }

        private static void DeletePatient()
        {
            Console.WriteLine("\n\n Delete Patient:\n");
            Console.WriteLine("Enter Patient ID: ");
            int id = Convert.ToInt32(Console.ReadLine());
            using (var db = new HospitalContext())
            {
                p = db.Patients.Find(id);
                db.Patients.Remove(p);
                db.SaveChanges();
                Console.WriteLine(p.PatientName + " is deleted ");
            }
        }

        private static int Find_DocID(int PatID)
        {
            
            var result = db.Patients.Include(x => x.doctor);
            using (var db = new HospitalContext())
            {
                foreach (var item in result)
                {
                    if (item.PatientID == PatID)
                        return item.doctor.DocID;
                }
            }
            return 0;
        }
    }


}

