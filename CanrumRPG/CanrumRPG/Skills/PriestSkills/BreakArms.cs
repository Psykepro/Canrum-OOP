namespace CanrumRPG.Skills.PriestSkills
{
    using System.Timers;

    using Characters;
    using Enums;

    public class BreakArms : ActiveSkill
    {
        private const int Timeout = 6;

        public BreakArms()
            : base(15, 0, 0, 20, CharClass.Priest, 10)
        {
        }

        protected override void DefaultSkillAction(Character caster, Character target)
        {
            caster.CurrentMana -= this.ManaModifier;
            int modifier = (target.AttackRating * this.AttackModifier) / 100;

            target.AttackRating -= modifier;

            Timer t = new Timer(Timeout);
            t.Elapsed += (source, e) => this.OnTimeout(source, e, target, modifier);
            t.AutoReset = false;
            t.Enabled = true;
        }

        private void OnTimeout(object source, ElapsedEventArgs e, Character target, int modifier)
        {
            this.ReturnDefaultStats(target, modifier);
            var t = (Timer)source;
            t.Dispose();
        }

        private void ReturnDefaultStats(Character target, int modifier)
        {
            target.AttackRating += modifier;
        }
    }
}
