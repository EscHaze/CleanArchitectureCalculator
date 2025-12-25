namespace Calculator.Domain;

interface ICalculator
{
    (double, double) GetValues();
    double Add(double x, double y);
    double Substract(double x, double y);
    double Multiply(double x, double y);
    double Divide(double x, double y);
}