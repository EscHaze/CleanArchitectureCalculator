using Calculator.CalculatorServices;
using Calculator.Domain;

namespace CalculatorTests;

public class BasicCalculatorTests
{
    [Theory]
    [InlineData(10, 20, 30)]
    [InlineData(-5, 10, 5)]
    [InlineData(2.2, 10, 12.2)]
    public void PerformAddition_ReturnsCorrectValue(double x, double y, double expected)
    {
        var calculator = new BasicCalculator();
        var result = calculator.Add(x, y);
        Assert.Equal(expected, result);
    }
    [Theory]
    [InlineData(20, 10, 10)]
    [InlineData(-15, 5, -20)]
    [InlineData(32.1, 14.5, 17.6)]
    public void PerformSubtraction_ReturnsCorrectValue(double x, double y, double expected)
    {
        var calculator = new BasicCalculator();
        var result = calculator.Subtract(x, y);
        Assert.Equal(expected, result);
    }
    [Theory]
    [InlineData(20, 10, 200)]
    [InlineData(-10, -2, 20)]
    [InlineData(42.4, 11.7, 496.08)]
    public void PerformMultiplication_ReturnsCorrectValue(double x, double y, double expected)
    {
        var calculator = new BasicCalculator();
        var result = calculator.Multiply(x, y);
        Assert.Equal(expected, result, precision: 2);
    }
    [Theory]
    [InlineData(10, 20, 0.5)]
    [InlineData(-10, 5, -2)]
    [InlineData(11.2, 5, 2.24)]
    public void PerformDivision_ReturnsCorrectValue(double x, double y, double expected)
    {
        var calculator = new BasicCalculator();
        var result = calculator.Divide(x, y);
        Assert.Equal(expected, result, precision: 2);
    }
    [Fact]
    public void PerformDivision_ByZero_ThrowsDivideByZeroException()
    {
        var calculator = new BasicCalculator();
        Assert.Throws<DivideByZeroException>(() => calculator.Divide(5, 0));
    }
    [Theory]
    [InlineData(double.NaN, 5)]
    [InlineData(5, double.NaN)]
    [InlineData(double.NaN, double.NaN)]
    public void Add_WithNaN_ThrowsArgumentException(double x, double y)
    {
        var calculator = new BasicCalculator();
        var exception = Assert.Throws<ArgumentException>(() => calculator.Add(x, y));
        Assert.Contains("NaN", exception.Message);
    }
    [Theory]
    [InlineData(double.PositiveInfinity, 5)]
    [InlineData(5, double.NegativeInfinity)]
    public void AnyOperation_WithInfinity_ThrowsArgumentException(double x, double y)
    {
        var calculator = new BasicCalculator();
        var exception = Assert.Throws<ArgumentException>(() => calculator.Add(x, y));
        Assert.Contains("infinite", exception.Message);
    }
}