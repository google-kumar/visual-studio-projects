using System;


namespace Shape
{
    abstract class shape
    {
        public string color { get; set; }
        protected float area;

        public virtual void AcceptDetails()
        {
            Console.WriteLine("enter the colour");
            color = Console.ReadLine();
        
        }
        public abstract void CalculateArea();

        public virtual void DisplayDetails()
        {
            Console.WriteLine("color: "+color);
            Console.WriteLine("Area: "+area);   
        }

        public void dummy()
        {
            Console.WriteLine("hi");
        }

    }
    class Rectangle:shape
    {
        int length, breadth;

       
       //public void dummy()
       // {
       //     Console.WriteLine("hi");
       // }

       // public new void dummy()
       // {
       //     Console.WriteLine("hi");
       // };

        public override void AcceptDetails()
        {
           base.AcceptDetails();
            Console.WriteLine("enter the Length and Breadth");
            int.TryParse(Console.ReadLine(), out length);
            breadth = Convert.ToInt32(Console.ReadLine());
        }
        public override void CalculateArea()
        {
            area = length * breadth;
        }
        public override void DisplayDetails()
        {
            base.DisplayDetails();
            Console.WriteLine("length: "+length);
            Console.WriteLine("breadth: "+breadth);
        }
    }

    class Circle : shape
    {
        int radius;

        public override void AcceptDetails()
        {
            base.AcceptDetails();
            Console.WriteLine("enter the radius ");
            int.TryParse(Console.ReadLine(), out radius);
        }

        public override void CalculateArea()
        {
            area = float.Parse((3.14 * radius * radius).ToString());
        }

        public override void DisplayDetails()
        {
            base.DisplayDetails();
            Console.WriteLine("radius: "+radius);
        }
    }

}
