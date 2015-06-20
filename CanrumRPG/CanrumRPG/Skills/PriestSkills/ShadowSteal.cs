﻿using CanrumRPG.Characters;
using CanrumRPG.Enums;

namespace CanrumRPG.Skills.PriestSkills
{
    class ShadowSteal:ActiveSkill
    {
        public ShadowSteal() 
            : base(30, 0, 20, 20, CharClass.Priest, 6)
        {
        }

        protected override void DefaultSkillAction(Character caster, Character target)
        {
            caster.CurrentMana -= this.ManaModifier;
            target.CurrentHealth -= this.AttackModifier;
            caster.CurrentHealth += this.HealthModifier;
        }
    }
}