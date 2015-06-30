namespace CanrumRPG.UI
{
    using System;

    using CanrumRPG.Interfaces;

    public class ConsoleRenderer : IRenderer
    {
        public void WriteLine(string message, params object[] paramaters)
        {
            Console.WriteLine(message, paramaters);
        }

        public void Clear()
        {
            Console.Clear();
        }
    }
}
