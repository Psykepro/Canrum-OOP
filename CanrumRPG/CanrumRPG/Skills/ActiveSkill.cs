﻿namespace CanrumRPG.Skills
{
    using System.Timers;

    using Enums;

    using global::CanrumRPG.Characters;

    public abstract class ActiveSkill : Skill
    {
        private bool isReady;

        protected ActiveSkill(int attackModifier, int defenseModifier, int healthModifier, int manaModifier, int coolDown)
            : base(attackModifier, defenseModifier, healthModifier, manaModifier, Skills.Active)
        {
            this.isReady = true;
            this.CoolDown = coolDown;
        }

        private int CoolDown { get; set; }

        public void Use(Character target)
        {
            if (this.isReady)
            {
                this.DefaultSkillAction(target);
                this.isReady = false;
                Timer t = new Timer(this.CoolDown);
                t.Elapsed += this.OnCooldown;
                t.AutoReset = false;
                t.Enabled = true;
            }
        }

        protected abstract void DefaultSkillAction(Character target);

        private void OnCooldown(object source, ElapsedEventArgs e)
        {
            this.isReady = true;
            var t = (Timer)source;
            t.Dispose();
        }
    }
}