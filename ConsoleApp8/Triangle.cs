using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApp8
{
    class Triangle: Shape
    {
        double Cathetus1;
        double Cathetus2;

        public Triangle(double cath1, double cath2) 
        {
            Cathetus1 = cath1;
            Cathetus2 = cath2;
        }
        public override void Show()
        {
            Console.WriteLine();
            Console.WriteLine("Triangle:");
            Console.WriteLine("Первый катет: " + Cathetus1 + "\nВторой катет: " + Cathetus2);
        }
        public override double Area()
        {
            return Cathetus1 * Cathetus2 * 0.5;
        }

        public override void Save(StreamWriter write_to_file)
        {
            write_to_file.WriteLine("Triangle");
            write_to_file.WriteLine(Cathetus1);
            write_to_file.WriteLine(Cathetus2);

        }

        public override void Load(StreamReader read_file)
        {
            Cathetus1 = double.Parse(read_file.ReadLine());
            Cathetus2 = double.Parse(read_file.ReadLine());
        }
    }
}
