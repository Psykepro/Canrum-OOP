namespace CanrumRPG.Items.Equippable
{
    using CanrumRPG.Attributes;
    using CanrumRPG.Engine;

    [Treasure]
    public class HelmOfProtection : Equipped
    {
        public HelmOfProtection(Position position)
            : base(position, "HelmOfProtection", 0, 13, 0, 0)
        {
        }
    }
}
