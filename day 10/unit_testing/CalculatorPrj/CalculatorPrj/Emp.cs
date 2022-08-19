using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace CalculatorPrj
{
    public class Emp
    {
        public List<Emp> emp = new List<Emp>();
        public int eid;
        public string ename;
        public double sal;

        public Emp()
        {
        }

        public Emp(int eid, string ename, double sal)
        {
            this.eid = eid;
            this.ename = ename;
            this.sal = sal;
        }

        public List<Emp> AddEmployeeData()
        {
            emp.Add(new Emp(1, "Deepak", 62000));
            emp.Add(new Emp(2, "Atul", 65000));
            emp.Add(new Emp(3, "Basid", 63000));
            emp.Add(new Emp(4, "Santo", 64000));
            return emp;
        }


    }
}