namespace CanrumRPG.Skills.NPCSkills
{
    using Characters;

    using Enums;

    using System.Timers;

    using global::CanrumRPG.Engine;

    public class HealSpirit : PassiveSkill
    {
        private const int Interval = 5*1000;
        public HealSpirit(CharClass charClass) : base(0, 0, 10, 0, charClass)
        {
        }

        public override void ApplySkillStats(Character caster)
        {

            Timer t = new Timer(Interval);
            t.Elapsed += (source, e) => this.OnTick(source, e, caster);
            t.AutoReset = false;
            t.Enabled = true;
        }

        private void OnTick(object source, System.Timers.ElapsedEventArgs e, Character caster)
        {
            if (caster.CurrentHealth > caster.MaxHealth)
            {
                caster.CurrentHealth = caster.MaxHealth;
            }
            caster.CurrentHealth += this.HealthModifier;
            GameEngine.Renderer.WriteLine("{0} healed {1} with {2} health",this.GetType().Name,caster.Name,this.HealthModifier);
        }
    }
}
