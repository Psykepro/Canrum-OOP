using System.Reflection;

namespace CanrumRPG.Skills.WarriorSkills
{
    using Characters;
    using Enums;

    public class Hedgehog : PassiveSkill
    {
        public Hedgehog()
            : base(10, 0, 0, 0, CharClass.Warrior)
        {
        }

        protected override void ApplySkillStats(Character caster)
        {
        }
    }
}
