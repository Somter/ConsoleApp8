using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp8
{
    abstract class Shape
    {
        public abstract void Show();
        public abstract double Area();
        public abstract void Save(StreamWriter writer);
        public abstract void Load(StreamReader reader);

    }
}
