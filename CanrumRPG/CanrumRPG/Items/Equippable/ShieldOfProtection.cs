namespace CanrumRPG.Items.Equippable
{
    using CanrumRPG.Attributes;
    using CanrumRPG.Engine;

    [Treasure]
    public class ShieldOfProtection : Equipped
    {
        public ShieldOfProtection(Position position)
            : base(position, "ShieldOfProtection", 0, 12, 0, 0)
        {
        }
    }
}
