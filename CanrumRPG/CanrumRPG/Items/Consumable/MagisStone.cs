
namespace CanrumRPG.Items.Consumable
{
    using System.Timers;

    using CanrumRPG.Characters;
    using CanrumRPG.Engine;

    public class MagisStone : Consumable
    {
        private const int Timeout = 5*1000;
        public MagisStone(Position position) 
                    : base(position, "Magic Stone", 0, 20, 100, 100)
        {
        }

        protected override void DefaultItemAction(Character caster, Character target)
        {
            caster.CurrentHealth += this.HealthModifier;
            caster.CurrentMana += this.ManaModifier;
            caster.DefenseRating += this.DefenseModifier;

            if (caster.CurrentHealth > caster.MaxHealth)
            {
                caster.CurrentHealth = caster.MaxHealth;
            }

            if (caster.CurrentMana > caster.MaxMana)
            {
                caster.CurrentMana = caster.MaxMana;
            }

            Timer t=new Timer(Timeout);
            t.AutoReset = false;
            t.Enabled = true;
            t.Elapsed+=(source, e)=>this.OnTimeout(source, e, caster);
            GameEngine.Renderer.WriteLine("{0} used {1} regenerated {2} health, {3} mana and increased Defense Rating with {4} for 5 seconds."
                , caster.Name, this.GetType().Name, this.HealthModifier, this.ManaModifier, this.DefenseModifier);
        }

        private void OnTimeout(object source, object o, Character caster)
        {
            caster.DefenseRating -= this.DefenseModifier;
            var t = (Timer) source;
            t.Dispose();
        }
    }
}
