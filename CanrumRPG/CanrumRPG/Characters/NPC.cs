namespace CanrumRPG.Characters
{
    using Attributes;

    using Engine;

    using Enums;

    [Enemy]
    public class Npc : Character
    {
        public Npc(Position position, string name, Race race, CharClass charClass)
            : base(position, MapMarkers.E, name, race, charClass, false)
        {
            this.FillInventory();
            this.SetPassiveSkills();
        }

        private void FillInventory()
        {
            // TODO;
        }

        private void SetPassiveSkills()
        {
            // TODO;
        }
    }
}