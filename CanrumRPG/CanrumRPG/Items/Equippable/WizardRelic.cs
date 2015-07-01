namespace CanrumRPG.Items.Equippable
{
    using CanrumRPG.Attributes;
    using CanrumRPG.Engine;

    [Treasure]
    public class WizardRelic : Equipped
    {
        public WizardRelic(Position position)
                    : base(position, "WizardRelic", 30, 0, 0, 0)
        {
        }
    }
}
