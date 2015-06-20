using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CanrumRPG.Characters;
using CanrumRPG.Enums;

namespace CanrumRPG.Skills.MageSkills
{
    class ManaSteal:ActiveSkill
    {
        public ManaSteal() 
            : base(0, 0, 0, 100, CharClass.Mage, 8)
        {
        }

        protected override void DefaultSkillAction(Character caster, Character target)
        {
            target.CurrentMana -= this.ManaModifier;
            caster.CurrentMana += this.ManaModifier;
        }
    }
}
