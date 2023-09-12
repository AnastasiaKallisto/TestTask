using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task.Messages
{
    public interface IMessages
    {
        void WriteDescription();

        void WriteDescriptionForKeyboardInput();

        void WriteDescriptionForFileInput();

        void WriteErrorMessage(string errorMessage);

        void WriteTwoRoots(double x1, double x2);

        void WriteOneRoot(double x);

        void WriteNoRoots();

        void WriteAnswer(double[] answer);

    }
}
