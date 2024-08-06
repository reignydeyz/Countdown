using Countdown;
using Countdown.Business;

class Program
{
    private static Random _random = new Random();
    private static int _totalPoints = 0;

    private static readonly int _numberOfRounds = 4;
    private static readonly int _numberOfConsonants = 6;
    private static readonly int _numberOfVowels = 3;

    private static readonly LetterCollector _letterCollector =
        new LetterCollector(new ConsoleInputProvider(), _numberOfConsonants, _numberOfVowels);

    private static readonly WordValidator _wordValidator = new WordValidator();

    static void Main()
    {
        Console.WriteLine("Welcome to the Countdown Letters Game!");

        for (int round = 1; round <= _numberOfRounds; round++)
        {
            InitializeRound(round);
        }
    }

    static void InitializeRound(int round)
    {
        Console.WriteLine("\n\n");
        Console.WriteLine("Round " + round);
        Console.WriteLine("You need to choose 6 consonants and 3 vowels.");

        var letters = _letterCollector.GetUserDefinedLetters();
        Console.WriteLine($"\nYour letters are: {string.Join(", ", letters)}");

        // Placeholder for user word input and scoring
        string userWord = GetUserWord();
        if (_wordValidator.IsValidWord(userWord, letters))
        {
            int score = GetScore(userWord);
            _totalPoints += score;
            Console.WriteLine($"Valid word! Points scored: {score}");
        }
        else
        {
            Console.WriteLine("Invalid word or not using the given letters.");
        }

        Console.WriteLine($"\nTotal Points: {_totalPoints}");

        Console.WriteLine(round < _numberOfRounds
            ? "Press any key to continue to the next round..."
            : "Press any key to exit...");

        Console.ReadKey();
    }

    static string GetUserWord()
    {
        string userWord;
        do
        {
            Console.Write("Enter your word: ");
            userWord = Console.ReadLine().Trim().ToLower();
            if (string.IsNullOrEmpty(userWord))
            {
                Console.WriteLine("The word cannot be empty. Please enter a valid word.");
            }
        } while (string.IsNullOrEmpty(userWord));

        return userWord;
    }

    static int GetScore(string word)
    {
        return word.Length; // Scoring based on the length of the word
    }
}
