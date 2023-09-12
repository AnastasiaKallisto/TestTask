using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task.Solver
{
    public interface ISquareEquationSolver
    {
        public double[] SolveEquation(double a, double b, double c);
    }
}
