namespace CanrumRPG.Items.Equippable
{
    using CanrumRPG.Attributes;
    using CanrumRPG.Engine;

    [Treasure]
    public class BladesOfAttack : Equipped
    {
        public BladesOfAttack(Position position)
            : base(position, "BladesOfAttack", 15, 0, 0, 0)
        {
        }
    }
}
