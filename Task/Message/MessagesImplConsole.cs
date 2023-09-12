using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task.Messages
{

    public class MessagesImplConsole : IMessages
    {

        public void WriteDescription()
        {
            Console.Clear();
            Console.WriteLine("Программа решает квадратное уравнение вида:");
            Console.WriteLine("ax^2 + bx + c = 0");
            Console.WriteLine("Выберите способ ввода данных: 1 - вручную, 2 - из файла");
        }

        public void WriteDescriptionForKeyboardInput()
        {
            Console.Clear();
            Console.WriteLine($"Введите коэффициенты a b c через пробел.\nПример ввода: 12 45 27");
        }

        public void WriteDescriptionForFileInput()
        {
            Console.Clear();
            Console.WriteLine("Введите полный путь к файлу, из которого будут читаться коэффициенты уравнений:");
        }

        public void WriteErrorMessage(string errorMessage)
        {
            Console.WriteLine(errorMessage);
            Console.WriteLine("\nНажмите любую клавишу, чтобы продолжить:");
        }

        public void WriteTwoRoots(double x1, double x2)
        {
            Console.WriteLine($"\nКорни уравнения: x1 = {x1}, x2 = {x2}");
        }

        public void WriteOneRoot(double x)
        {
            Console.WriteLine($"\nУравнение имеет единственный корень: x = {x}");
        }

        public void WriteNoRoots()
        {
            Console.WriteLine("\nУравнение не имеет действительных корней");
        }

        public void WriteAnswer(double[] answer)
        {
            if (answer.Length == 2)
            {
                WriteTwoRoots(answer[0], answer[1]);
            }
            else if (answer.Length == 1)
            {
                WriteOneRoot(answer[0]);
            }
            else
            {
                WriteNoRoots();
            }
        }
    }
}
