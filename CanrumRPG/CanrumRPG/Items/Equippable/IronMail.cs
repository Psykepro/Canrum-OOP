namespace CanrumRPG.Items.Equippable
{
    using CanrumRPG.Attributes;
    using CanrumRPG.Engine;

    [Treasure]
    public class IronMail : Equipped
    {
        public IronMail(Position position)
            : base(position, "IronMail", 0, 12, 0, 0)
        {
        }
    }
}
