using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.Input;
using Task.Messages;
using Task.Solver;

namespace Task
{
    public static class Program
    {
        public static readonly ISquareEquationSolver solver = new SquareEquationSolver();
        public static readonly IMessages messages = new MessagesImplConsole();
        public static ConsoleKeyInfo keyInfo;
        public static IInput input;
        static void Main(string[] args)
        {
            menu();
        }

        public static void menu()
        {
            double[] array;
            double[] answer;
            bool one, two;

            while (true)
            {
                messages.WriteDescription();
                try
                {
                    keyInfo = Console.ReadKey();
                    one = IsKeyboardInput(keyInfo);
                    two = IsFileInput(keyInfo);
                    if (one)
                    {
                        messages.WriteDescriptionForKeyboardInput();
                        input = new KeyboardConsoleInput();
                        array = input.GetNumbers();
                        answer = solver.SolveEquation(array[0], array[1], array[2]);
                        messages.WriteAnswer(answer);
                        break;
                    }
                    else if (two)
                    {
                        messages.WriteDescriptionForFileInput();
                        input = new FileInput(Console.ReadLine());
                        array = input.GetNumbers();
                        while (array != null)
                        {
                            answer = solver.SolveEquation(array[0], array[1], array[2]);
                            messages.WriteAnswer(answer);
                            array = input.GetNumbers();
                        }
                        break;
                    }
                }
                catch (Exception e)
                {
                    WriteErrorMessage(e);
                }
            }
        }

        private static bool IsFileInput(ConsoleKeyInfo keyInfo)
        {
            return keyInfo.Key == ConsoleKey.D2 || keyInfo.Key == ConsoleKey.NumPad2;
        }

        private static bool IsKeyboardInput(ConsoleKeyInfo keyInfo)
        {
            return keyInfo.Key == ConsoleKey.D1 || keyInfo.Key == ConsoleKey.NumPad1;
        }

        private static void WriteErrorMessage(Exception e)
        {
            messages.WriteErrorMessage(e.Message);
            Console.ReadKey();
        }
    }
}
