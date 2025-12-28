using Calculator.Domain;
namespace Calculator.CalculatorServices;

public class CalculatorClass : ICalculator
{
    public double Add(double x, double y) => x + y;
    public double Subtract(double x, double y) => x - y;
    public double Multiply(double x, double y) => x * y;
    public double Divide(double x, double y) => x / y;
}