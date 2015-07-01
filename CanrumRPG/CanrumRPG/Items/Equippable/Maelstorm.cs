namespace CanrumRPG.Items.Equippable
{
    using CanrumRPG.Attributes;
    using CanrumRPG.Engine;

    [Treasure]
    public class Maelstorm : Equipped
    {
        public Maelstorm(Position position)
            : base(position, "Maelstorm", 19, 0, 0, 0)
        {
        }
    }
}
