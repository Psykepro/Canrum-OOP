namespace CanrumRPG.Skills
{
    using Enums;

    using Interfaces;

    public abstract class Skill : ISkillModifiers
    {
        protected Skill(int attackModifier, int defenseModifier, int healthModifier, int manaModifier, Skills type, CharClass charClass)
        {
            this.AttackModifier = attackModifier;
            this.DefenseModifier = defenseModifier;
            this.HealthModifier = healthModifier;
            this.ManaModifier = manaModifier;
            this.Type = type;
            this.CharClass = charClass;
        }

        public int AttackModifier { get; set; }

        public int DefenseModifier { get; set; }

        public int HealthModifier { get; set; }

        public int ManaModifier { get; set; }

        public Skills Type { get; set; }

        public CharClass CharClass { get; set; }

        public override string ToString()
        {
            return this.GetType().Name;
        }

    }

    
}