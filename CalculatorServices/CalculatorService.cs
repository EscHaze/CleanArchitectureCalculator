using Calculator.Domain;
namespace Calculator.CalculatorServices;

public class Calculator : ICalculator
{
    public double Add(double x, double y) => x + y;
    public double Subtract(double x, double y) => x - y;
    public double Multiply(double x, double y) => x * y;
    public double Divide(double x, double y) => x / y;
}

public class CalculatorService
{
    private readonly ICalculator _calculator;
    public CalculatorService(ICalculator calculator) => _calculator = calculator;
    public double PerformAddition(double x, double y)
    {
        return _calculator.Add(x, y);
    }
    public double PerformSubtraction(double x, double y)
    {
        return _calculator.Subtract(x, y);
    }
    public double PerformMultiplication(double x, double y)
    {
        return _calculator.Multiply(x, y);
    }
    public double PerformDivision(double x, double y)
    {
        if (y == 0)
        {
            throw new DivideByZeroException("Can't divide by zero!");
        }
        return _calculator.Divide(x, y);
    }
}
