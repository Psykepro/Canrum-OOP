using CanrumRPG.Characters;
using CanrumRPG.Enums;

namespace CanrumRPG.Skills.WarriorSkills
{
    class StrongArms:PassiveSkill
    {
        public StrongArms()
            : base(15, 0, 0, 0, CharClass.Warrior)
        {
        }

        protected override void ApplySkillStats(Character caster)
        {
            caster.AttackRating += this.AttackModifier;
        }
    }
}
