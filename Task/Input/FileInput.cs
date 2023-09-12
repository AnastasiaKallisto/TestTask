using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.Messages;

namespace Task.Input
{
    public class FileInput : IInput
    {
        private readonly string[] _lines;
        private int _currentIndex;

        public FileInput(string filename)
        {
            _lines = File.ReadAllLines(filename);
            _currentIndex = 0;
            Validator.ValidateFileLines(_lines);
        }

        public double[]? GetNumbers()
        {
            if (_currentIndex >= _lines.Length)
            {
                return null;
            }

            string line = _lines[_currentIndex];

            if (string.IsNullOrWhiteSpace(line))
            {
                _currentIndex++;
                return GetNumbers();
            }
            
            _currentIndex++;
            return Validator.ValidateAndParseNumbers(line);
        }
    }
}
