namespace CanrumRPG.UI
{
    using System;

    using CanrumRPG.Interfaces;

    public class ConsoleInputReader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
