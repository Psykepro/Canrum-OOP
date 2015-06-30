namespace CanrumRPG.Skills.RogueSkills
{
    using System;

    using CanrumRPG.Characters;

    public class SliceSliceSlice : ActiveSkill
    {
        private const int Timeout = 1000;

        public SliceSliceSlice()
            : base(0, 0, 0, 80, 7)
        {
        }

        protected override void DefaultSkillAction(Character caster, Character target)
        {
            Random rnd =new Random();
            caster.CurrentMana -= this.ManaModifier;
            for (int i = 0; i <=3 ; i++)
            {
                caster.Attack(target, rnd);
            }
        }
    }
}
