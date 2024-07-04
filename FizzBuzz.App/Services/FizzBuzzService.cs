using FizzBuzz.App.Exceptions;
using Microsoft.Extensions.Logging;

namespace FizzBuzz.App.Services;

public class FizzBuzzService : IMultiplesService
{
    private readonly ILogger<FizzBuzzService> _logger;

    public FizzBuzzService(ILogger<FizzBuzzService> logger)
    {
        _logger = logger;
    }

    // these could have just been properties on the interface, but i thought it would be fun to have more tests to run
    public string MultipleOfThree()
    {
        return "Fizz";
    }

    public string MultipleOfFive()
    {
        return "Buzz";
    }

    public string MultipleOfThreeAndFive()
    {
        return "FizzBuzz";
    }

    public void LogResults(IEnumerable<string> results)
    {
        _logger.LogInformation("Logging FizzBuzz results...");
        foreach (var result in results)
        {
            Console.WriteLine(result);
        }
        _logger.LogInformation("Done logging.");
    }

    public IEnumerable<string> Execute(int range)
    {
        if (range <= 0)
        {
            _logger.LogError($"FizzBuzz range invalid. Given: {range}");
            throw new InvalidFizzBuzzRangeException("Range must be greater than 0.");
        }
        _logger.LogInformation("Creating FizzBuzz results...");

        // Demonstrating my preference for Linq, but of course this could be written as a for loop as well.
        return Enumerable.Range(1, range)
            .Select(i =>
            {
                if (i % 3 == 0 && i % 5 == 0)
                {
                    return MultipleOfThreeAndFive();
                }

                if (i % 3 == 0)
                {
                    return MultipleOfThree();
                }

                if (i % 5 == 0)
                {
                    return MultipleOfFive();
                }

                return i.ToString();
            });

        // I find this too terse for someone to parse at first glance, but it's a cool usage of linq and language features
        /*
         return Enumerable.Range(1, range)
            .Select(i => (i % 3 == 0, i % 5 == 0) switch
            {
                (true, true) => "FizzBuzz",
                (true, false) => "Fizz",
                (false, true) => "Buzz",
                _ => i.ToString()
            });
        */
    }
}