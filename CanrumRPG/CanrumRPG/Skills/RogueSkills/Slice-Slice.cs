using System;
using System.Diagnostics;

namespace CanrumRPG.Skills.RogueSkills
{
    using System.Timers;

    using Characters;
    using Enums;

    class SliceSlice : ActiveSkill
    {
        private const int Timeout = 1000;
        public SliceSlice()
            : base(120, 0, 0, 80, CharClass.Rogue, 7)
        {
        }

        protected override void DefaultSkillAction(Character caster, Character target)
        {
            caster.CurrentMana -= this.ManaModifier;
            target.CurrentHealth -= this.AttackModifier;

            Timer t=new Timer(Timeout);
            t.Elapsed += (source, e) => this.OnTimeout(source, e, target);
        }

        private void OnTimeout(object source, EventArgs e, Character target)
        {
            target.CurrentHealth -= this.AttackModifier;
            var t = (Timer) source;
            t.Dispose();
        }
    }
}
