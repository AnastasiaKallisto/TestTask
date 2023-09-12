namespace Task.Solver
{
    public class SquareEquationSolver : ISquareEquationSolver
    {
        // корни в порядке возрастания
        public double[] SolveEquation(double a, double b, double c)
        {
            double D = b * b - 4 * a * c;
            if (D > 0)
            {
                return new double[] { (-b - Math.Sqrt(D)) / (2 * a), (-b + Math.Sqrt(D)) / (2 * a) };
            }
            else if (D == 0)
            {
                return new double[] { -b / (2 * a) };
            }
            return new double[] { };
        }
    }
}
