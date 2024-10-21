using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp8
{
    class ShapesArray
    {
        Shape[] shapes;
        int size;

        public ShapesArray() 
        { 
            shapes = new Shape[2];
            size = 0;
        }

        public int Size
        {
            get { return size; }
        }

        public Shape this[int index] // Это индексатор для доступа к фигурам в классе Menu
        {
            get
            {
                if (index < 0 || index >= size)
                {
                    throw new IndexOutOfRangeException("Индекс вне диапазона массива.");
                }
                return shapes[index];
            }
        }

        // добавлем фигуру
        public void Add(Shape shape) 
        {
            if (size == shapes.Length)
            {
                Shape[] newShapes = new Shape[shapes.Length * 2];
                for (int i = 0; i < shapes.Length; i++)
                {
                    newShapes[i] = shapes[i];
                }
                shapes = newShapes;
            }

            shapes[size] = shape;
            size++;
        }

        //удаляем фигуру
        public void Remove(Shape shape)
        {
            int index = Array.IndexOf(shapes, shape, 0, size); // получаем индекс фигуры которую нужно удалить
            if (index >= 0)
            {
               
                for (int i = index; i < size - 1; i++)
                {
                    shapes[i] = shapes[i + 1];
                }
                shapes[size - 1] = null;
                size--;
                Console.WriteLine("");
            }
            
        }

        // печатем все фигуры
        public void Print() 
        {
            for (int i = 0; i < size; i++) 
            {
                shapes[i].Show();
            }
        }

        // Выводим фигуры указаного типа
        public void OutputSpecifiedFigure(string figure) 
        {
            bool figureFound = false; 
            for (int i = 0; i < size; i++)
            {
                Shape shape = shapes[i];
                if (figure == "Triangle" && shape is Triangle)
                {
                    shape.Show();
                    figureFound = true; 
                }
                else if (figure == "Rectangle" && shape is Rectangle)
                {
                    shape.Show();
                    figureFound = true;
                }
                else if (figure == "Circle" && shape is Circle)
                {
                    shape.Show();
                    figureFound = true;
                }
            }

            if (!figureFound)
            {
                Console.WriteLine("Такой фигуры нет.");
            }
        }

        // вычисляем плозадь фигуры
        public void AreaFigure() 
        {
            Console.WriteLine("");
            double area;
            for (int i = 0; i < size; i++)
            {
                area = shapes[i].Area();
                Console.WriteLine("Плоащадь " + i + " фигуры: " + area);  
            }
        }

        // вычисляем площадь фигуры указанного типа
        public void AreaTypeFigure(string figure) 
        {
            Console.WriteLine("");
            double area;    
            bool figureFound = false;
            for (int i = 0; i < size; i++)
            {
                Shape shape = shapes[i];
                if (figure == "Triangle" && shape is Triangle)
                {
                    area = shape.Area();
                    Console.WriteLine("Плоащадь треугольника: " + area);
                    figureFound = true;
                }
                else if (figure == "Rectangle" && shape is Rectangle)
                {
                    area = shape.Area();
                    Console.WriteLine("Плоащадь прямоугольника: " + area);
                    figureFound = true;
                }
                else if (figure == "Circle" && shape is Circle)
                {
                    area = shape.Area();
                    Console.WriteLine("Плоащадь круга: " + area);
                    figureFound = true;
                }
            }

            if (!figureFound)
            {
                Console.WriteLine("Такой фигуры нет.");
            }
        }

        // сохраняем фигуры в файл
        public void Save() 
        {
            using (StreamWriter writer = new StreamWriter("Figure.txt")) 
            {
                for (int i =0;i < size; i++) 
                {
                    shapes[i].Save(writer);                       
                }
            }
            Console.WriteLine("Фигуры сохранены в файл");
        }

        // загружаем фигурі из файла
        public void Load() 
        {
            size = 0;

            using (StreamReader read = new StreamReader("Figure.txt")) 
            {
                while (!read.EndOfStream)
                {
                    string shapeType = read.ReadLine();
                    Shape shape = null;

                    if (shapeType == "Triangle")
                    {
                        shape = new Triangle(0, 0);
                    }
                    else if (shapeType == "Rectangle")
                    {
                        shape = new Rectangle(0, 0, 0, 0);
                    }
                    else if (shapeType == "Circle")
                    {
                        shape = new Circle(0, 0, 0);
                    }

                    if (shape != null)
                    {
                        shape.Load(read); 
                        Add(shape);   
                    }
                }
            }
            Console.WriteLine("Фигуры загружены из файла");
        }
    }


}
