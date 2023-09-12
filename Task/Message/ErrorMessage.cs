using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task.Messages
{
    public class ErrorMessage
    {
        public const string INCORRECT_INPUT = "Должно быть три числа. Десятичные дроби должны быть с запятой.";
        public const string ERROR_IN_WORK_WITH_FILE = "Ошибка при работе с файлом.";
        public const string VOID_STRING_IN_FILE = "Первая строка файла пустая. В ней должно быть три числа через пробел.";
        public const string VOID_FILE = "Файл пуст.";
        public const string INCORRECT_QUANTITY = "Должно быть три вещественных числа. ";
    }
}
