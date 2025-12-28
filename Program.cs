using Calculator.CalculatorConsoleUI;
using Calculator.CalculatorServices;
using Calculator.Domain;
using Microsoft.Extensions.DependencyInjection;
class Program
{
    static void Main()
    {
        // try
        // {
        //     var calculator = new CalculatorClass();
        //     var service = new CalculatorService(calculator);
        //     var console = new CalculatorConsole(service);
        //     console.Run();
        // }
        // catch(Exception ex)
        // {
        //     Console.WriteLine($"Error: {ex.Message}");
        // }
        var services = new ServiceCollection();
        services.AddTransient<ICalculator, CalculatorClass>();
        services.AddTransient<CalculatorService>();
        services.AddSingleton<CalculatorConsole>();
        var provider = services.BuildServiceProvider();
        try
        {
            var console = provider.GetRequiredService<CalculatorConsole>();
            console.Run();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}