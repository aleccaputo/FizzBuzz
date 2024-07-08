using FizzBuzz.App.Exceptions;
using FizzBuzz.App.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

// using statement will dispose the host
using var host = InjectTheDependencies();
await host.StartAsync();

var validInput = false;

while (!validInput)
{
    Console.WriteLine("Enter the range for FizzBuzz:");
    if (int.TryParse(Console.ReadLine(), out var inputtedRange))
    {
        try
        {
            await FizzBuzz(host.Services, inputtedRange).ConfigureAwait(false);
            validInput = true;
        }
        catch (InvalidFizzBuzzRangeException)
        {
            // Don't leak service layer exception message
            Console.WriteLine("Invalid range given. Please give a range greater than 0.");
        }
    }
    else
    {
        Console.WriteLine("Invalid input. Please enter a valid integer.");
    }
}

await host.StopAsync();
return;

static async Task FizzBuzz(IServiceProvider serviceProvider, int range)
{
    using IServiceScope serviceScope = serviceProvider.CreateScope();
    var provider = serviceScope.ServiceProvider;
    var fizzBuzzService = provider.GetRequiredService<IMultiplesService>();

    var fizzBuzz = await fizzBuzzService.Execute(range).ConfigureAwait(false);
    fizzBuzzService.LogResults(fizzBuzz);
}

static IHost InjectTheDependencies()
{
    return Host.CreateDefaultBuilder()
        .ConfigureServices((context, services) =>
        {
            // choosing singleton, service has no state and is thread safe.
            services.AddSingleton<IMultiplesService, FizzBuzzService>();
            services.AddLogging(x => x.AddConsole());
        })
        .Build();
}
