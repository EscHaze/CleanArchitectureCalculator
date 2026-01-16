using Calculator.Domain;
namespace Calculator.CalculatorServices;

public class BasicCalculator : ICalculator
{
    public double Add(double x, double y)
    {
        ValidateInputs(x, y);
        return x + y;
    }
    public double Subtract(double x, double y)
    {
        ValidateInputs(x, y);
        return x - y;
    }
    public double Multiply(double x, double y)
    {
        ValidateInputs(x, y);
        return x * y;
    }
    public double Divide(double x, double y)
    {
        ValidateInputs(x, y);
        if (y == 0) throw new DivideByZeroException("Can't divide by zero.");
        return x / y;
    }
    private static void ValidateInputs(double x, double y)
    {
        if (double.IsNaN(x) || double.IsNaN(y))
            throw new ArgumentException("Value cannot be NaN.");
        if (double.IsInfinity(x) || double.IsInfinity(y))
            throw new ArgumentException("Value can't be infinite.");
    }
}