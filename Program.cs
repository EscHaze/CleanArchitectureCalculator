using Calculator.CalculatorConsoleUI;
using Calculator.CalculatorServices;

class Program
{
    static void Main()
    {
        try
        {
            var calculator = new CalculatorClass();
            var service = new CalculatorService(calculator);
            var console = new CalculatorConsole(service);
            console.Run();
        }
        catch(Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}