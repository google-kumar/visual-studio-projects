using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shape
{
    internal class shape_Main
    {
        public static void main()
        {
            //shape s = new shape();
            //s.AcceptDetails();
            //s.CalculateArea();
            //s.DisplayDetails();

            Rectangle r = new Rectangle();
            r.AcceptDetails();
            r.CalculateArea();
            r.DisplayDetails();
            Circle c=new Circle();
            c.AcceptDetails(); //override - derived class
            c.CalculateArea();
            c.DisplayDetails();

            shape s = new Rectangle(); //dynamic polymorphism
            s.AcceptDetails(); // override - derived class
            s.CalculateArea();
            s.DisplayDetails();
            s = new Circle();
            s.AcceptDetails(); // if we give new instead of ovverride in shape.cs - circle's acceptdetails() it will call only base method, if we give ovverride it will call derived
            s.CalculateArea();
            s.DisplayDetails();

        }

    }
}
