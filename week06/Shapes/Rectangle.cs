public class Rectangle : Shape
{
    private double _length;
    private double _width;

    // Constructor passing color to base class and setting length and width
    public Rectangle(string color, double length, double width) : base(color)
    {
        _length = length;
        _width = width;
    }

    // Override GetArea for a rectangle
    public override double GetArea()
    {
        return _length * _width;
    }
}