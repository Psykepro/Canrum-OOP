namespace CanrumRPG.UI
{
    using System;

    using Interfaces;

    public class ConsoleInputReader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
