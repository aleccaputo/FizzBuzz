namespace FizzBuzz.App.Exceptions;

public class InvalidFizzBuzzRangeException : Exception
{
    public InvalidFizzBuzzRangeException()
    {
    }

    public InvalidFizzBuzzRangeException(string message)
        : base(message)
    {
    }

    public InvalidFizzBuzzRangeException(string message, Exception inner)
        : base(message, inner)
    {
    }
}