namespace CanrumRPG
{
    using CanrumRPG.Engine;
    using CanrumRPG.Interfaces;
    using CanrumRPG.UI;

    public static class CanrumRpg
    {
        public static void Main()
        {
            IRenderer renderer = new ConsoleRenderer();
            IReader reader = new ConsoleInputReader();

            GameEngine engine = new GameEngine(reader, renderer);

            engine.Run();
        }
    }
}
