using System.Globalization;
using Calculator.CalculatorServices;
using Calculator.Domain;
namespace Calculator.CalculatorConsoleUI;

public class CalculatorConsole(ICalculator service)
{
    private readonly ICalculator _service = service;
    public void Run()
    {
        Console.Clear();
        Console.WriteLine("Welcome to calculator app");
        while (true)
        {
            Console.Write("Select action (+, -, *, /, 0 to exit): ");
            string? action = Console.ReadLine()?.Trim();
            if (string.IsNullOrWhiteSpace(action))
            {
                Console.WriteLine("Invalid input");
                continue;
            }
            if (action == "0")
            {
                return;
            }
            if (!IsValidAction(action))
            {
                Console.WriteLine("Invalid operation. Please use +, -, *, or /");
                continue;
            }
            Console.WriteLine("Please type two numbers.");
            (double x, double y) = GetValues();
            if (action == "/" && y == 0)
            {
                Console.WriteLine("Error: Cannot divide by zero!");
                Pause();
                continue;
            }
            try
            {
                var result = action switch
                {
                    "+" => _service.Add(x, y),
                    "-" => _service.Subtract(x, y),
                    "*" => _service.Multiply(x, y),
                    "/" => _service.Divide(x, y),
                    _ => throw new InvalidOperationException("Invalid operation.")
                };
                Console.WriteLine($"{x} {action} {y} = {result}");
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine($"Error {ex.Message}");
            }
            Pause();
        }
    }
    private bool IsValidAction(string action)
    {
        return action is "+" or "-" or "*" or "/";
    }
    private static void Pause()
    {
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
        Console.Clear();
    }
    public (double, double) GetValues()
    {
        Console.Write("First number: ");
        double x = Validator();
        Console.Write("Second number: ");
        double y = Validator();
        return (x, y);
    }
    public double Validator()
    {
        while (true)
        {
            string? input = Console.ReadLine()?.Trim();
            if (TryParseDouble(input, out double output))
            {
                return output;
            }
            Console.WriteLine("Invalid value.");
            Console.Write("Try again: ");
        }
    }
    private static bool TryParseDouble(string? input, out double result)
    {
        result = 0;
        if (string.IsNullOrWhiteSpace(input))
            return false;
        if (double.TryParse(input, out result))
            return true;
        string normalInput = input.Replace(',', '.');
        if (double.TryParse(normalInput, CultureInfo.InvariantCulture, out result))
            return true;
        return false;
    }
}
