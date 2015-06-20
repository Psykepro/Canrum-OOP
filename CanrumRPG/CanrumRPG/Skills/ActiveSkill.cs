namespace CanrumRPG.Skills
{
    using System.Timers;

    using Characters;

    using Enums;

    public abstract class ActiveSkill : Skill
    {
        private bool isReady;

        protected ActiveSkill(int attackModifier, int defenseModifier, int healthModifier, int manaModifier, CharClass charClass, int coolDown)
            : base(attackModifier, defenseModifier, healthModifier, manaModifier, Skills.Active, charClass)
        {
            this.isReady = true;
            this.CoolDown = coolDown * 1000;
        }

        private int CoolDown { get; set; }

        public void Use(Character caster, Character target)
        {
            if (this.isReady)
            {
                this.DefaultSkillAction(caster, target);
                this.isReady = false;
                Timer t = new Timer(this.CoolDown);
                t.Elapsed += this.OnCooldown;
                t.AutoReset = false;
                t.Enabled = true;
            }
        }

        protected abstract void DefaultSkillAction(Character caster, Character target);

        private void OnCooldown(object source, ElapsedEventArgs e)
        {
            this.isReady = true;
            var t = (Timer)source;
            t.Dispose();
        }
    }
}