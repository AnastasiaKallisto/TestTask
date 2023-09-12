using Task.Solver;
namespace Task.Tests
{
    public class SquareEquationSolverTests
    {

        [Theory]
        [InlineData(2, 5, -3.5, -3.0, 0.5)]
        [InlineData(1, 2, 1, -1.0)]
        [InlineData(1, 0, 1)]
        [InlineData(1, 4, 1, -3.732051, -0.267949)]
        public static void SolveEquationTest_ReturnsExpectedResults(
            double a, double b, double c, params double[] expectedRoots)
        {
            // Arrange
            SquareEquationSolver solver = new ();

            // Act
            double[] result = solver.SolveEquation(a, b, c);

            // Assert
            Assert.Equal(expectedRoots.Length, result.Length);
            for (int i = 0; i < expectedRoots.Length; i++)
            {
                Assert.Equal(expectedRoots[i], result[i], 1E-1);
            }
        }
    }
}