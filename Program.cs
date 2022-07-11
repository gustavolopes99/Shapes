using System;
using System.Collections.Generic;
using System.Globalization;
namespace Geometric
{
    class Program
    {
        static void Close(string[] args)
        {
            try
            {
                Console.Write("Close Application?(y/n) ");
                char yesno = char.Parse(Console.ReadLine());
                switch (yesno)
                {
                    case 'y':
                        Environment.Exit(0);
                        break;
                    case 'n':
                        Main(args);
                        break;
                    default:
                        while (true)
                        {
                            Close(args);
                        }
                }
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                Close(args);
            }
        }
        static void Main(string[] args)
        {
            try
            {
                List<Shape> shape = new List<Shape>();
                Console.Write("Enter the number of shapes: ");
                var num = int.Parse(Console.ReadLine());

                for (int i = 1; i <= num; i++)
                {
                    Console.WriteLine($"Shape #{i} data:");
                    Console.Write("Rectangle or Circle (r/c)? ");
                    var type = char.Parse(Console.ReadLine());
                    Console.Write("Color (Black/Blue/Red): ");
                    var color = (Color)Enum.Parse(typeof(Color), Console.ReadLine());
                    switch (type)
                    {
                        case 'r':
                            Console.Write("Width: ");
                            var width = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                            Console.Write("Height: ");
                            var height = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                            shape.Add(new Rectangle(width, height, color));
                            break;
                        case 'c':
                            Console.Write("Radius: ");
                            var radius = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                            shape.Add(new Circle(radius, color));
                            break;
                        default:
                            Console.WriteLine("Opção Inválida");
                            break;
                    }
                }
                Console.WriteLine("SHAPE AREAS:");
                foreach (var item in shape)
                {
                    Console.WriteLine(item.Area().ToString("F2", CultureInfo.InvariantCulture));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                Close(args);
            }
        }
    }
    enum Color
    {
        Black,
        Blue,
        Red
    }
    abstract class Shape
    {
        public Color Color { get; set; }
        public abstract double Area();
    }
    class Rectangle : Shape
    {
        public double Width { get; set; }
        public double Height { get; set; }
        public Rectangle(double width, double height, Color color)
        {
            Width = width;
            Height = height;
            Color = color;
        }
        public override double Area()
        {
            return Width * Height;
        }
    }
    class Circle : Shape
    {
        public double Radius { get; set; }
        public Circle(double radius, Color color)
        {
            Radius = radius;
            Color = color;
        }
        public override double Area()
        {
            return Math.PI * Math.Pow(Radius, 2);
        }
    }
}