namespace CanrumRPG.Skills.WarriorSkills
{
    using System.Timers;

    using CanrumRPG.Characters;
    using CanrumRPG.Engine;

    public class Armadillo : ActiveSkill
    {
        private const int Timeout = 6000;

        public Armadillo()
            : base(0, 7, 90, 25, 8)
        {
        }

        protected override void DefaultSkillAction(Character caster, Character target)
        {
            caster.CurrentMana -= this.ManaModifier;
            caster.MaxHealth += this.HealthModifier;
            caster.CurrentHealth += this.HealthModifier / 2;
            caster.DefenseRating += this.DefenseModifier;

            GameEngine.Renderer.WriteLine(
                string.Format(
                    "{0} casts {1} raising defensive stats.", 
                    caster.Name, 
                    this.GetType().Name));

            Timer t = new Timer(Timeout);
            t.Elapsed += (source, e) => this.OnTimeout(source, e, caster);
            t.AutoReset = false;
            t.Enabled = true;
        }

        private void OnTimeout(object source, ElapsedEventArgs e, Character caster)
        {
            this.ReturnDefaultStats(caster);
            var t = (Timer)source;
            t.Dispose();
        }

        private void ReturnDefaultStats(Character caster)
        {
            caster.MaxHealth -= this.HealthModifier;
            if (caster.CurrentHealth > caster.MaxHealth)
            {
                caster.CurrentHealth = caster.MaxHealth;
            }

            caster.DefenseRating -= this.DefenseModifier;

            GameEngine.Renderer.WriteLine(
                string.Format(
                    "{0}'s {1} effect wears off.", 
                    caster.Name, 
                    this.GetType().Name));
        }
    }
}
