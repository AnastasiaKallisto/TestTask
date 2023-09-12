using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.Messages;

namespace Task.Input
{
    public class Validator
    {
        public static void ValidateFileLines(string[] lines)
        {
            if (lines.Length == 0)
            {
                throw new ArgumentException(ErrorMessage.VOID_FILE);
            }
        }

        public static double[] ValidateAndParseNumbers(string line)
        {
            if (string.IsNullOrWhiteSpace(line))
            {
                throw new ArgumentException(ErrorMessage.INCORRECT_INPUT);
            }

            try
            {
                double[] arr = line.Split(' ').Select(double.Parse).ToArray();
                if (arr.Length != 3)
                {
                    throw new ArgumentException(ErrorMessage.INCORRECT_QUANTITY);
                }
                return arr;
            }
            catch (FormatException e)
            {
                throw new FormatException(ErrorMessage.INCORRECT_INPUT, e);
            }
            catch (ArgumentException e)
            {
                throw new ArgumentException(ErrorMessage.INCORRECT_INPUT, e);
            }
            catch (Exception e)
            {
                throw new Exception(ErrorMessage.INCORRECT_INPUT, e);
            }
        }
    }
}
