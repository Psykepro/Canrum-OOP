namespace CanrumRPG.UI
{
    using System;

    using global::CanrumRPG.Interfaces;

    public class ConsoleInputReader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
