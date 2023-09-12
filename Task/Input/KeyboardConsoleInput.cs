using Task.Messages;
using System;

namespace Task.Input
{
    public class KeyboardConsoleInput : IInput
    {
        public double[]? GetNumbers()
        {
            return Validator.ValidateAndParseNumbers(Console.ReadLine());
        }
    }
}
