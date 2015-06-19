namespace CanrumRPG
{
    using global::CanrumRPG.Engine;
    using global::CanrumRPG.Interfaces;
    using global::CanrumRPG.UI;

    public class CanrumRPG
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
