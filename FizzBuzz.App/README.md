# Welcome to FizzBuzz

This program is a self-contained console application written in .NET 8.

I set out to demonstrate as many core concepts I tend to use on a daily basis in C#/.NET even though they are probably overkill for a FizzBuzz console app.
1. Dependency Injection
2. A generic interface (IMultiplesService)
3. A concrete implementation (FizzBuzzService)
4. Async programming
5. Custom Exceptions
6. Best practices (like not "leaking" service layer exceptions)
7. Docker (although I was having trouble with docker + user input into the console)
8. Testing, with an alternative option with Moq

I would have included an exe but i doubt that would make it past the email filter\
I have included a dockerfile for your convenience.\
To build and run with docker:

**WARNING, PLEASE NOTE** the `-it` in the run command. Without it, you'll infinite loop as those options allow console input.
```
docker build -t fizz-buzz-app .
docker run -it fizz-buzz-app
```