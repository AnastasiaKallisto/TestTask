using System;
using System.IO;
using Task.Input;
using Task.Solver;
using Xunit;

namespace Task.Tests
{
    

    public class FileInputTests : IDisposable
    {
        private readonly string tempDir;

        public FileInputTests()
        {
            tempDir = Directory.GetCurrentDirectory() + "\\tempDirectory";
            Directory.CreateDirectory(tempDir);
        }

        [Fact]
        public void Constructor_InvalidFilePath_ThrowsFileNotFoundException()
        {
            // Arrange
            var invalidFilePath = Path.Combine(tempDir, "nonexistentFile.txt");

            // Act & Assert
            Assert.Throws<FileNotFoundException>(() => new FileInput(invalidFilePath));
        }

        [Fact]
        public void Constructor_EmptyFile_ThrowsArgumentException()
        {
            // Arrange
            var emptyFilePath = Path.Combine(tempDir, "emptyFile.txt");
            File.WriteAllText(emptyFilePath, "");

            // Act & Assert
            Assert.Throws<ArgumentException>(() => new FileInput(emptyFilePath));
        }

        [Fact]
        public void GetNumbers_WithFileWithErrorSymbols_ShouldThrowFormatException()
        {
            // Arrange
            string filePath = Path.Combine(tempDir, "fileWithErrorSymbols.txt");
            File.WriteAllText(filePath, "1q 2 3");
            var fileInput = new FileInput(filePath);

            // Act & Assert
            Assert.Throws<FormatException>(() => fileInput.GetNumbers());
        }

        [Fact]
        public void GetNumbers_WithFileOk_ShouldReadAndSolveAllLines()
        {
            // Arrange
            string filePath = Path.Combine(tempDir, "fileOk.txt");
            File.WriteAllText(filePath, "1 0 1\n2 5 -3,5\n1 1 1\n1 4 1\n1 2 1");
            var fileInput = new FileInput(filePath);
            var solver = new SquareEquationSolver();

            // Act
            double[] numbers = fileInput.GetNumbers();
            int linesRead = 0;

            while (numbers != null)
            {
                // Act: 
                double[] expectedRoots = GetExpectedRoots(linesRead);
                double[] actualRoots = solver.SolveEquation(numbers[0], numbers[1], numbers[2]);

                // Assert: 
                Assert.Equal(expectedRoots.Length, actualRoots.Length);
                for (int i = 0; i < expectedRoots.Length; i++)
                {
                    Assert.Equal(expectedRoots[i], actualRoots[i], 1E-1);
                }

                numbers = fileInput.GetNumbers();
                linesRead++;
            }

            // Assert: Check that all lines were read
            Assert.Equal(5, linesRead);
        }

        private double[] GetExpectedRoots(int index)
        {
            // Define the expected roots for each line based on the index
            switch (index)
            {
                case 0: return new double[] { };
                case 1: return new double[] { -3.0, 0.5 };
                case 2: return new double[] { };
                case 3: return new double[] { -3.732051, -0.267949 };
                case 4: return new double[] { -1.0 };
                default: throw new ArgumentOutOfRangeException(nameof(index));
            }
        }

        public void Dispose()
        {
            if (Directory.Exists(tempDir))
            {
                Directory.Delete(tempDir, true);
            }
        }
    }
}
