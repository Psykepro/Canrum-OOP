namespace CanrumRPG.Items.Equippable
{
    using CanrumRPG.Attributes;
    using CanrumRPG.Engine;

    [Treasure]
    public class AbbysalBlade : Equipped
    {
        public AbbysalBlade(Position position)
            : base(position, "AbbysalBlade", 23, 0, 0, 0)
        {
        }
    }
}
