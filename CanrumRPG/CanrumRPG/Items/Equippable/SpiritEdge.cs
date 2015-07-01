namespace CanrumRPG.Items.Equippable
{
    using CanrumRPG.Attributes;
    using CanrumRPG.Engine;

    [Treasure]
    public class SpiritEdge : Equipped
    {
        public SpiritEdge(Position position) 
                    : base(position, "SpiritEdge", 28, 0, 0, 0)
        {
        }
    }
}
