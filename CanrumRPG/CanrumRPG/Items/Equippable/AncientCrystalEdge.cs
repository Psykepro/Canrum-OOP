namespace CanrumRPG.Items.Equippable
{
    using CanrumRPG.Attributes;
    using CanrumRPG.Engine;

    [Treasure]
    public class AncientCrystalEdge : Equipped
    {
        public AncientCrystalEdge(Position position)
            : base(position, "AncientCrystalEdge", 26, 0, 0, 0)
        {
        }
    }
}
