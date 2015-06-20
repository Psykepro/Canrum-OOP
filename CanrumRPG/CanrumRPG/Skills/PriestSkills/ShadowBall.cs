using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CanrumRPG.Characters;
using CanrumRPG.Enums;

namespace CanrumRPG.Skills.PriestSkills
{
    class ShadowBall:ActiveSkill
    {
        public ShadowBall()
            : base(100, 0, 0, 60, CharClass.Priest, 10)
        {
        }

        protected override void DefaultSkillAction(Character caster, Character target)
        {
            caster.CurrentMana -= this.ManaModifier;
            target.CurrentHealth -= this.AttackModifier;
        }
    }
}
