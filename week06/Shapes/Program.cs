using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create a list to hold Shape objects
        List<Shape> shapes = new List<Shape>();

        // Create different shapes and add them to the list
        Square square = new Square("Red", 4.0);
        shapes.Add(square);

        Rectangle rectangle = new Rectangle("Blue", 5.0, 3.0);
        shapes.Add(rectangle);

        Circle circle = new Circle("Green", 2.5);
        shapes.Add(circle);

        // Iterate through the list polymorphically
        foreach (Shape shape in shapes)
        {
            string color = shape.GetColor();
            double area = shape.GetArea();

            Console.WriteLine($"The {color} shape has an area of {area:F2}.");
        }
    }
}