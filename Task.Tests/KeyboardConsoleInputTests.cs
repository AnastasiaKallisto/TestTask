using Task.Input;

namespace Task.Tests
{
    public class KeyboardConsoleInputTests
    {
        [Fact]
        public void GetNumbers_ValidInput_ReturnsDoubleArray()
        {
            // Arrange
            var input = new KeyboardConsoleInput();
            System.Console.SetIn(new System.IO.StringReader("1 2 3"));

            // Act
            var result = input.GetNumbers();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(3, result.Length);
            Assert.Equal(1.0, result[0]);
            Assert.Equal(2.0, result[1]);
            Assert.Equal(3.0, result[2]);
        }

        [Fact]
        public void GetNumbers_InvalidInputWithText_ThrowsException()
        {
            // Arrange
            var input = new KeyboardConsoleInput();
            System.Console.SetIn(new System.IO.StringReader("dfh 4 6"));

            // Act & Assert
            Assert.Throws<FormatException>(() => input.GetNumbers());
        }

        [Fact]
        public void GetNumbers_InvalidInputWithLessValues_ThrowsArgumentException()
        {
            // Arrange
            var input = new KeyboardConsoleInput();
            System.Console.SetIn(new System.IO.StringReader("1 2"));

            // Act & Assert
            Assert.Throws<ArgumentException>(() => input.GetNumbers());
        }

        [Fact]
        public void GetNumbers_InvalidInputWithExtraSpace_ThrowsArgumentException()
        {
            // Arrange
            var input = new KeyboardConsoleInput();
            System.Console.SetIn(new System.IO.StringReader("1 2 "));

            // Act & Assert
            Assert.Throws<FormatException>(() => input.GetNumbers());
        }
    }
}
