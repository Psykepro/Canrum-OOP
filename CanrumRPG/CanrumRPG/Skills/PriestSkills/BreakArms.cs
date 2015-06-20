using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CanrumRPG.Characters;
using CanrumRPG.Enums;

namespace CanrumRPG.Skills.PriestSkills
{
    class BreakArms:ActiveSkill
    {
        private const int Timeout = 6;
        public BreakArms() 
            : base(15, 0, 0, 20, CharClass.Priest, 10)
        {
        }

        protected override void DefaultSkillAction(Character caster, Character target)
        {
            caster.CurrentMana -= this.ManaModifier;
            target.AttackRating -= (target.AttackRating*this.AttackModifier)/100;
        }
    }
}
