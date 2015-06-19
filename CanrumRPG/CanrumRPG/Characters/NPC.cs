namespace CanrumRPG.Characters
{
    using System;
    using System.Collections.Generic;

    using Engine;
    using Enums;

    public class Npc : Character
    {
        private readonly List<Skills> passiveSkills;

        public Npc(Position position, string name, Race race, CharClass charClass)
            : base(position, MapMarkers.E, name, race, charClass, false)
        {
            this.passiveSkills = new List<Skills>();
            this.FillInventory();
            this.SetPassiveSkills();
        }

        private void FillInventory()
        {
            throw new NotImplementedException();
        }

        private void SetPassiveSkills()
        {
            throw new NotImplementedException();
        }
    }
}