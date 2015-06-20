using CanrumRPG.Characters;
using CanrumRPG.Enums;

namespace CanrumRPG.Skills.WarriorSkills
{
    class Armadillo:ActiveSkill
    {
        private const int Timeout = 6;
        public Armadillo()
            : base(0, 7, 90, 25, CharClass.Warrior, 8)
        {
        }

        protected override void DefaultSkillAction(Character caster, Character target)
        {
            caster.MaxHealth += this.HealthModifier;
            caster.CurrentHealth += this.HealthModifier/2;
            caster.DefenseRating += this.DefenseModifier;
            caster.CurrentMana -= this.ManaModifier;
        }
    }
}
