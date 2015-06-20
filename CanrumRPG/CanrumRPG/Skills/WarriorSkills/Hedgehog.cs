using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CanrumRPG.Characters;
using CanrumRPG.Enums;

namespace CanrumRPG.Skills.WarriorSkills
{
    class Hedgehog:ActiveSkill
    {
        public Hedgehog() 
            : base(0, 0, 0, 30, CharClass.Warrior, 10)
        {
        }

        protected override void DefaultSkillAction(Character caster, Character target)
        {
            caster.CurrentMana-=this.ManaModifier;
            target.CurrentHealth -= (target.AttackRating*10)/100;
        }
    }
}
