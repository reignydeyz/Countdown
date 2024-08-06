using Countdown.Business.Interfaces;

namespace Countdown
{
    public class ConsoleInputProvider : IInputProvider
    {
        public char ReadChar(string prompt)
        {
            Console.Write(prompt);
            return Char.ToLower(Console.ReadKey().KeyChar);
        }
    }
}
