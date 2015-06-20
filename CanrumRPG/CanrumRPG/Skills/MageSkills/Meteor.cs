using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CanrumRPG.Characters;
using CanrumRPG.Enums;

namespace CanrumRPG.Skills.MageSkills
{
    class Meteor:ActiveSkill
    {
        public Meteor() 
            : base(120, 0, 0, 60, CharClass.Mage, 6)
        {
        }

        protected override void DefaultSkillAction(Character caster, Character target)
        {
            caster.CurrentMana -= this.ManaModifier;
            target.CurrentHealth -= this.AttackModifier;
        }
    }
}
