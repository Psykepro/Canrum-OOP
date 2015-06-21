﻿namespace CanrumRPG.Skills.PriestSkills
{
    using Characters;
    using Enums;

    public class ShadowBall : ActiveSkill
    {
        public ShadowBall()
            : base(120, 0, 0, 60, CharClass.Priest, 9)
        {
        }

        protected override void DefaultSkillAction(Character caster, Character target)
        {
            caster.CurrentMana -= this.ManaModifier;
            target.CurrentHealth -= this.AttackModifier;
        }
    }
}
