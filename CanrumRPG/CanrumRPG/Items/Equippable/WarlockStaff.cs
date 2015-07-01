namespace CanrumRPG.Items.Equippable
{
    using CanrumRPG.Attributes;
    using CanrumRPG.Engine;

    [Treasure]
    public class WarlockStaff : Equipped
    {
        public WarlockStaff(Position position)
                    : base(position, "WarlockStaff", 19, 0, 0, 0)
        {
        }
    }
}
