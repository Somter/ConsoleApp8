using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp8
{
    class ClassMenu
    {
        ShapesArray shapesArray;

        public ClassMenu()
        {
            shapesArray = new ShapesArray();
        }

        public void ShowMenu()
        {
            while (true)
            {
                Console.WriteLine("\nВыберите действие:");
                Console.WriteLine("1. Добавить фигуру");
                Console.WriteLine("2. Удалить фигуру");
                Console.WriteLine("3. Печать всех фигур");
                Console.WriteLine("4. Печать фигур указанного типа");
                Console.WriteLine("5. Вычислить площадь всех фигур");
                Console.WriteLine("6. Вычислить площадь фигур указанного типа");
                Console.WriteLine("7. Сохранить фигуры в файл");
                Console.WriteLine("8. Загрузить фигуры из файла");
                Console.WriteLine("0. Выход");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddShape();
                        break;
                    case "2":
                        RemoveShape();
                        break;
                    case "3":
                        shapesArray.Print();
                        break;
                    case "4":
                        OutputSpecifiedFigure();
                        break;
                    case "5":
                        shapesArray.AreaFigure();
                        break;
                    case "6":
                        AreaTypeFigure();
                        break;
                    case "7":
                        shapesArray.Save();
                        break;
                    case "8":
                        shapesArray.Load();
                        break;
                    case "0":
                        Console.WriteLine("Выход из программы.");
                        return; 
                    default:
                        Console.WriteLine("Некорректный ввод. Попробуйте снова.");
                        break;
                }
            }
        }

        private void AddShape()
        {
            Console.WriteLine("Выберите тип фигуры для добавления (Triangle, Rectangle, Circle):");
            string shapeType = Console.ReadLine();

            Shape shape = null;

            if (shapeType.Equals("Triangle", StringComparison.OrdinalIgnoreCase))
            {
                Console.Write("Введите длины катетов (a b): ");
                string[] parts = Console.ReadLine().Split(' ');
                double cathetus1 = double.Parse(parts[0]);
                double cathetus2 = double.Parse(parts[1]);
                shape = new Triangle(cathetus1, cathetus2);
            }
            else if (shapeType.Equals("Rectangle", StringComparison.OrdinalIgnoreCase))
            {
                Console.Write("Введите координаты левого верхнего и правого нижнего углов (x1 y1 x2 y2): ");
                string[] parts = Console.ReadLine().Split(' ');
                double x1 = double.Parse(parts[0]);
                double y1 = double.Parse(parts[1]);
                double x2 = double.Parse(parts[2]);
                double y2 = double.Parse(parts[3]);
                shape = new Rectangle(x1, y1, x2, y2);
            }
            else if (shapeType.Equals("Circle", StringComparison.OrdinalIgnoreCase))
            {
                Console.Write("Введите координаты центра и радиус (x y radius): ");
                string[] parts = Console.ReadLine().Split(' ');
                double x = double.Parse(parts[0]);
                double y = double.Parse(parts[1]);
                double radius = double.Parse(parts[2]);
                shape = new Circle(x, y, radius);
            }
            else
            {
                Console.WriteLine("Некорректный тип фигуры.");
                return;
            }

            shapesArray.Add(shape);
            Console.WriteLine($"{shapeType} добавлена.");
        }

        private void RemoveShape()
        {
            Console.WriteLine("Введите тип фигуры для удаления (Triangle, Rectangle, Circle):");
            string shapeType = Console.ReadLine();

            Shape shapeToRemove = null;

            for (int i = 0; i < shapesArray.Size; i++)
            {
                Shape shape = shapesArray[i];
                if (shapeType.Equals("Triangle", StringComparison.OrdinalIgnoreCase) && shape is Triangle)
                {
                    shapeToRemove = shape;
                    break;
                }
                else if (shapeType.Equals("Rectangle", StringComparison.OrdinalIgnoreCase) && shape is Rectangle)
                {
                    shapeToRemove = shape;
                    break;
                }
                else if (shapeType.Equals("Circle", StringComparison.OrdinalIgnoreCase) && shape is Circle)
                {
                    shapeToRemove = shape;
                    break;
                }
            }

            if (shapeToRemove != null)
            {
                shapesArray.Remove(shapeToRemove);
                Console.WriteLine($"{shapeType} удалена.");
            }
            else
            {
                Console.WriteLine("Фигура не найдена.");
            }
        }

        private void OutputSpecifiedFigure()
        {
            Console.WriteLine("Введите тип фигуры для вывода (Triangle, Rectangle, Circle):");
            string figure = Console.ReadLine();
            shapesArray.OutputSpecifiedFigure(figure);
        }

        private void AreaTypeFigure()
        {
            Console.WriteLine("Введите тип фигуры для вычисления площади (Triangle, Rectangle, Circle):");
            string figure = Console.ReadLine();
            shapesArray.AreaTypeFigure(figure);
        }
    }
}
