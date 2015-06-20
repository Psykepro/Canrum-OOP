using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CanrumRPG.Characters;
using CanrumRPG.Enums;

namespace CanrumRPG.Skills.WarriorSkills
{
    class Overpower:ActiveSkill
    {
        public Overpower() : base(0, 0, 0, 25, CharClass.Warrior, 10)
        {
        }

        protected override void DefaultSkillAction(Character caster, Character target)
        {
            caster.CurrentMana -= this.ManaModifier;
            target.CurrentHealth -= caster.AttackRating*3;
        }
    }
}
