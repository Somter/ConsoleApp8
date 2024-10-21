using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp8
{
    class Rectangle : Shape
    {
        double x1;
        double y1;
        double x2;
        double y2;

        public Rectangle(double first_x, double first_y, double second_x, double second_y) 
        {
            x1 = first_x;
            y1 = first_y;
            x2 = second_x;
            y2 = second_y;
        }

        public override void Show() 
        {
            Console.WriteLine();
            Console.WriteLine("Rectangle:");
            Console.WriteLine("X1: " + x1 + "\nX2: " + x1 + "\nY1: " + y1 + "\nY2: " + y2);    
        }

        public override double Area()
        {
            return Math.Abs((x2 - x1) * (y2 - y1)); 
        }

        public override void Save(StreamWriter writer)
        {
            writer.WriteLine("Rectangle");
            writer.WriteLine(x1);
            writer.WriteLine(y1);
            writer.WriteLine(x2);
            writer.WriteLine(y2);
        }

        public override void Load(StreamReader reader)
        {
            x1 = double.Parse(reader.ReadLine());
            y1 = double.Parse(reader.ReadLine());   
            x2 = double.Parse(reader.ReadLine());
            y2 = double.Parse(reader.ReadLine());   
        }

    }
}
