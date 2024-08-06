using Countdown.Business.Interfaces;

namespace Countdown.Test
{
    internal class MockInputProvider : IInputProvider
    {
        private readonly Queue<char> _inputs;

        public MockInputProvider(IEnumerable<char> inputs)
        {
            _inputs = new Queue<char>(inputs);
        }

        public char ReadChar(string prompt)
        {
            // Return the next input character
            return _inputs.Dequeue();
        }
    }
}
