namespace CanrumRPG.Items.Equippable
{
    using CanrumRPG.Attributes;
    using CanrumRPG.Engine;

    [Treasure]
    public class EtheralBladeOfPain : Equipped
    {
        public EtheralBladeOfPain(Position position) 
                        : base(position, "EtheralBladeOfPain", 36, 0, 0, 0)
        {
        }
    }
}
