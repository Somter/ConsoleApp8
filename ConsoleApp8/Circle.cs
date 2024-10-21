using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp8
{
    class Circle : Shape
    {
        double x;
        double y;
        double radius;

        public Circle(double point_x, double point_y, double value_radius) 
        { 
            x = point_x;
            y = point_y;
            radius = value_radius;
        }

        public override void Show() 
        {
            Console.WriteLine();
            Console.WriteLine("Circle:");
            Console.WriteLine("X: " + x + "\nY: " + y + "\nRadius: " + radius);
        }

        public override double Area()
        {
            return Math.PI * radius * radius;
        }

        public override void Save(StreamWriter writer)
        {
            writer.WriteLine("Circle");
            writer.WriteLine(x);
            writer.WriteLine(y);
            writer.WriteLine(radius);
        }

        public override void Load(StreamReader reader)
        {
            x = double.Parse(reader.ReadLine());
            y = double.Parse(reader.ReadLine());
            radius = double.Parse(reader.ReadLine());   
        }

    }
}
