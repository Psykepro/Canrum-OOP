using CanrumRPG.Characters;
using CanrumRPG.Enums;

namespace CanrumRPG.Skills.PriestSkills
{
    class Glory:ActiveSkill
    {
        public Glory() 
            : base(0, 0, 50, 20, CharClass.Priest, 8)
        {
        }

        protected override void DefaultSkillAction(Character caster, Character target)
        {
            caster.CurrentMana -= this.ManaModifier;
            caster.CurrentHealth += this.HealthModifier;
        }
    }
}
