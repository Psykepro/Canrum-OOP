﻿using CanrumRPG.Characters;
using CanrumRPG.Enums;

namespace CanrumRPG.Skills.RogueSkills
{
    class ThrowKnife:ActiveSkill
    {
        public ThrowKnife()
            : base(50, 0, 0, 20, CharClass.Rogue, 6)
        {
        }

        protected override void DefaultSkillAction(Character caster, Character target)
        {
            caster.CurrentMana -= this.ManaModifier;
            target.CurrentHealth -= this.AttackModifier;
        }
    }
}
