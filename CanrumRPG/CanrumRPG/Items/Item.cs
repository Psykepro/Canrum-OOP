namespace CanrumRPG.Items
{
    using Engine;
    using Enums;
    using Interfaces;

    public abstract class Item : GameObject, ISkillModifiers
    {
        protected Item(Position position, string name, int attackModifier, int defenseModifier, int healthModifier, int manaModifier, Skills type)
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
    }
}
