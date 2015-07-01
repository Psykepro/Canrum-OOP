namespace CanrumRPG.Items.Equippable
{
    using CanrumRPG.Attributes;
    using CanrumRPG.Engine;

    [Treasure]
    public class IronRingOfProtection : Equipped
    {
        public IronRingOfProtection(Position position)
            : base(position, "IronRingOfProtection", 0, 10, 0, 0)
        {
        }
    }
}
