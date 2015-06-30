namespace CanrumRPG.Characters
{
    using System;

    using CanrumRPG.Attributes;
    using CanrumRPG.Engine;
    using CanrumRPG.Enums;
    using CanrumRPG.Skills;

    [Enemy]
    public class Npc : Character
    {
        public Npc(Position position, string name, Race race, CharClass charClass, Random rand)
            : base(position, MapMarkers.E, name, race, charClass, false)
        {
            this.FillInventory();
            this.SetPassiveSkills(rand);
        }

        private void FillInventory()
        {
            // TODO;
        }

        private void SetPassiveSkills(Random rand)
        {
            while (this.PassiveSkills.Count < 2)
            {
                var skill = (PassiveSkill)Resources.NpcSkills[rand.Next(Resources.NpcSkills.Count)];

                if (!this.PassiveSkills.Contains(skill))
                {
                    this.PassiveSkills.Add(skill);
                }
            }

            foreach (var skill in this.PassiveSkills)
            {
                skill.ApplySkillStats(this);
            }
        }
    }
}