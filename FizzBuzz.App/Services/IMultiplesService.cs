namespace FizzBuzz.App.Services;

public interface IMultiplesService
{
    public string MultipleOfThree();

    public string MultipleOfFive();

    public string MultipleOfThreeAndFive();

    public void LogResults(IEnumerable<string> results);

    public IEnumerable<string> Execute(int range);
}