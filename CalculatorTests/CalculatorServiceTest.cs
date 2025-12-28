using Calculator.CalculatorServices;

namespace CalculatorTests;

public class CalculatorServiceTest
{
    private readonly CalculatorService _service;
    public CalculatorServiceTest()
    {
        _service = new CalculatorService(new CalculatorClass());
    }
    [Theory]
    [InlineData(10, 20, 30)]
    [InlineData(-5, 10, 5)]
    [InlineData(2.2, 10, 12.2)]
    public void PerformAddition_ReturnsCorrectValue(double x, double y, double expected)
    {
        var result = _service.PerformAddition(x, y);
        Assert.Equal(expected, result);
    }
    [Theory]
    [InlineData(20, 10, 10)]
    [InlineData(-15, 5, -20)]
    [InlineData(32.1, 14.5, 17.6)]
    public void PerformSubtraction_ReturnsCorrectValue(double x, double y, double expected)
    {
        var result = _service.PerformSubtraction(x, y);
        Assert.Equal(expected, result);
    }
    [Theory]
    [InlineData(20, 10, 200)]
    [InlineData(-10, -2, 20)]
    [InlineData(42.4, 11.7, 496.08)]
    public void PerformMultiplication_ReturnsCorrectValue(double x, double y, double expected)
    {
        var result = _service.PerformMultiplication(x, y);
        Assert.Equal(expected, result, precision: 2);
    }
    [Theory]
    [InlineData(10, 20, 0.5)]
    [InlineData(-10, 5, -2)]
    [InlineData(11.2, 5, 2.24)]
    public void PerformDivision_ReturnsCorrectValue(double x, double y, double expected)
    {
        var result = _service.PerformDivision(x, y);
        Assert.Equal(expected, result, precision: 2);
    }
    [Fact]
    public void PerformDivision_ByZero_ThrowsDivideByZeroException()
    {
        Assert.Throws<DivideByZeroException>(() => _service.PerformDivision(5, 0));
    }
}
