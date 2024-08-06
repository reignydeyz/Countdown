using WeCantSpell.Hunspell;

namespace Countdown.Business
{
    public class WordValidator
    {
        public bool IsValidWord(string word, List<char> letters)
        {
            var letterCounts = letters.GroupBy(c => c).ToDictionary(g => g.Key, g => g.Count());
            foreach (var c in word)
            {
                if (!letterCounts.ContainsKey(c) || letterCounts[c] <= 0)
                    return false;
                letterCounts[c]--;
            }

            var dictionary = WordList.CreateFromFiles(@"index.dic");

            return dictionary.Check(word);
        }
    }
}
