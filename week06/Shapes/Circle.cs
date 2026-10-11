using System;

public class Circle : Shape
{
    private double _radius;

    // Constructor passing color to base class and setting radius
    public Circle(string color, double radius) : base(color)
    {
        _radius = radius;
    }

    // Override GetArea for a circle
    public override double GetArea()
    {
        return Math.PI * _radius * _radius;
    }
}