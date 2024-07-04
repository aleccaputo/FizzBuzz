# Welcome to FizzBuzz

This program is a self-contained console application written in .NET 8.

I would have included an exe but i doubt that would make it past the email filter\
I have included a dockerfile for your convenience.\
To build and run with docker:

**WARNING, PLEASE NOTE** the `-it` in the run command. Without it, you'll infinite loop as those options allow console input.
```
docker build -t fizz-buzz-app .
docker run -it fizz-buzz-app
```