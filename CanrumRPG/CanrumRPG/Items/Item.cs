namespace CanrumRPG.Items
{
    using CanrumRPG.Engine;
    using CanrumRPG.Enums;
    using CanrumRPG.Interfaces;

    public class Item : GameObject, ISkillModifiers
    {
        protected internal Item(Position position, string name, int attackModifier, int defenseModifier, int healthModifier, int manaModifier, Skills type)
            : base(position, MapMarkers.T, name)
        {
            this.ItemState = ItemState.Available;
            this.AttackModifier = attackModifier;
            this.DefenseModifier = defenseModifier;
            this.HealthModifier = healthModifier;
            this.ManaModifier = manaModifier;
            this.Type = type;
        }

        public ItemState ItemState { get; set; }

        public int AttackModifier { get; set; }

        public int DefenseModifier { get; set; }

        public int HealthModifier { get; set; }

        public int ManaModifier { get; set; }

        public Skills Type { get; set; }

        public override string ToString()
        {
            return string.Format("{0} - {1}\n+{2} AR, +{3} DR, +{4} H, +{5} M", this.Name, this.ItemState, this.AttackModifier, this.DefenseModifier, this.HealthModifier, this.ManaModifier);
        }
    }
}
