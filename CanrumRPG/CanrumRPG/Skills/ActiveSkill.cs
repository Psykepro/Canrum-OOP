namespace CanrumRPG.Skills
{
    using System.Timers;

    using Characters;

    using Engine;

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
                if (caster.CurrentMana < this.ManaModifier)
                {
                    GameEngine.Renderer.WriteLine(string.Format("Not enough mana to cast {0}!", this.GetType().Name));
                    return;
                }

                this.DefaultSkillAction(caster, target);
                this.isReady = false;
                Timer t = new Timer(this.CoolDown);
                t.Elapsed += this.OnCooldown;
                t.AutoReset = false;
                t.Enabled = true;
            }
            else
            {
                GameEngine.Renderer.WriteLine("{0} is not ready to use yet!", this.GetType().Name);
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