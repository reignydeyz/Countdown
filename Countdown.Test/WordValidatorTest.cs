using Countdown.Business;

namespace Countdown.Test
{
    public class WordValidatorTest
    {
        [Theory]
        [InlineData("boy", new char[] { 'b', 'c', 'd', 'e', 'a', 'y', 'o' })]
        [InlineData("bed", new char[] { 'b', 'c', 'd', 'e', 'a', 'y', 'o' })]
        [InlineData("day", new char[] { 'b', 'c', 'd', 'e', 'a', 'y', 'o' })]
        public void IsValidWord_Success(string word, char[] letters)
        {
            // Arrange
            var validator = new WordValidator();

            // Act
            var result = validator.IsValidWord(word, letters.ToList());

            // Assert
            Assert.True(result);
        }

        [Theory]
        [InlineData("car", new char[] { 'b', 'c', 'd', 'e', 'a', 'y', 'o' })]
        [InlineData("girl", new char[] { 'b', 'c', 'd', 'e', 'a', 'y', 'o' })]
        [InlineData("pillow", new char[] { 'b', 'c', 'd', 'e', 'a', 'y', 'o' })]
        public void IsValidWord_Failed(string word, char[] letters)
        {
            // Arrange
            var validator = new WordValidator();

            // Act
            var result = validator.IsValidWord(word, letters.ToList());

            // Assert
            Assert.False(result);
        }
    }
}
