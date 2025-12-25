using Calculator.CalculatorServices;
namespace Calculator.CalculatorConsoleUI;

public class CalculatorConsole
{
    private CalculatorService _service;
    public CalculatorConsole(CalculatorService service) => _service = service;
    public void Run()
    {
        Console.WriteLine("Welcome to calculator app");
        while (true)
        {
            Console.WriteLine("Please type two numbers.");
            (double x, double y) = GetValues();
            Console.Write("Select action (+, -, *, /, 0 to exit): ");
            string? action = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(action))
            {
                Console.WriteLine("Invalid input");
                continue;
            }
            switch (action)
            {
                case "+":
                    Console.WriteLine($"{x} + {y} = {_service.PerformAddition(x, y)}");
                    break;
                case "-":
                    Console.WriteLine($"{x} - {y} = {_service.PerformSubtraction(x, y)}");
                    break;
                case "*":
                    Console.WriteLine($"{x} * {y}= {_service.PerformMultiplication(x, y)}");
                    break;
                case "/":
                    Console.WriteLine($"{x} / {y} = {_service.PerformDivision(x, y)}");
                    break;
                case "0":
                    return;
                default:
                    Console.WriteLine("Invalid input.");
                    break;
            }
        }
    }
    public static (double, double) GetValues()
    {
        while (true)
        {
            Console.Write("First number: ");
            double x = Validator();
            Console.Write("Second number: ");
            double y = Validator();
            return (x, y);
        }
    }
    public static double Validator()
    {
        while (true)
        {
            string? input = Console.ReadLine();
            if (!double.TryParse(input, out double output))
            {
                Console.WriteLine("Invalid value. Try again!");
                continue;
            }
            return output;
        }
    }
}
