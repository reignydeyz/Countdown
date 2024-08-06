using Countdown.Business;

namespace Countdown.Test
{
    public class LetterCollectorTest
    {
        [Fact]
        public void GetUserDefinedLetters_Success()
        {
            // Arrange
            var mockInputProvider = new MockInputProvider(new char[] { 'b', 'c', 'd', 'e', 'a' });
            var collector = new LetterCollector(mockInputProvider, 3, 2);

            // Act
            var result = collector.GetUserDefinedLetters();

            // Assert
            var expected = new List<char> { 'b', 'c', 'd', 'e', 'a' };
            Assert.Equal(expected, result);
        }


        [Fact]
        public void GetUserDefinedLetters_ShouldThrowExceptionOnInputFailure()
        {
            // Arrange
            var mockInputProvider = new MockInputProvider(new char[] { 'b', 'c', 'd', 'e', 'a' });
            var collector = new LetterCollector(mockInputProvider, 3, 3);

            // Act & Assert
            var exception = Assert.Throws<InvalidOperationException>(() => collector.GetUserDefinedLetters());
            Assert.Equal("Queue empty.", exception.Message);
        }
    }
}