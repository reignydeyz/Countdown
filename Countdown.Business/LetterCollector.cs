using Countdown.Business.Interfaces;

namespace Countdown.Business
{
    public class LetterCollector
    {
        private readonly IInputProvider _inputProvider;
        private readonly int _numberOfConsonants;
        private readonly int _numberOfVowels;

        public LetterCollector(IInputProvider inputProvider, int numberOfConsonants, int numberOfVowels)
        {
            _inputProvider = inputProvider;
            _numberOfConsonants = numberOfConsonants;
            _numberOfVowels = numberOfVowels;
        }

        public List<char> GetUserDefinedLetters()
        {
            var letters = new List<char>();

            // Collect consonants from user
            Console.WriteLine($"Please enter {_numberOfConsonants} consonants:");
            for (int i = 0; i < _numberOfConsonants; i++)
            {
                char letter;
                do
                {
                    letter = _inputProvider.ReadChar($"Consonant {i + 1}: ");
                    Console.WriteLine();
                    if (IsConsonant(letter))
                    {
                        letters.Add(letter);
                        break;
                    }
                    else
                        Console.WriteLine("Please enter a valid consonant.");
                } while (letters.Count < _numberOfConsonants);
            }

            // Collect vowels from user
            Console.WriteLine($"Please enter {_numberOfVowels} vowels:");
            for (int i = 0; i < _numberOfVowels; i++)
            {
                char letter;
                do
                {
                    letter = _inputProvider.ReadChar($"Vowel {i + 1}: ");
                    Console.WriteLine();
                    if (IsVowel(letter))
                    {
                        letters.Add(letter);
                        break;
                    }
                    else
                        Console.WriteLine("Please enter a valid vowel.");
                } while (letters.Count < _numberOfVowels);
            }

            return letters;
        }

        private bool IsConsonant(char c)
        {
            // Implement your consonant checking logic here
            return "bcdfghjklmnpqrstvwxyz".Contains(c);
        }

        private bool IsVowel(char c)
        {
            // Implement your vowel checking logic here
            return "aeiou".Contains(c);
        }
    }

}
