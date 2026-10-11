public class Square : Shape
{
    private double _side;

    // Constructor passing color to base class and setting side
    public Square(string color, double side) : base(color)
    {
        _side = side;
    }

    // Override GetArea for a square
    public override double GetArea()
    {
        return _side * _side;
    }
}