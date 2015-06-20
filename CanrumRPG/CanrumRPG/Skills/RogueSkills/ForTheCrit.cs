using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CanrumRPG.Enums;

namespace CanrumRPG.Skills.RogueSkills
{
    class ForTheCrit:PassiveSkill
    {
        public ForTheCrit() 
            : base(25, 0, 0, 0, CharClass.Rogue)
        {
        }

        protected override void ApplySkillStats(Characters.Character caster)
        {
            caster.CritChance += this.AttackModifier;
        }
    }
}
