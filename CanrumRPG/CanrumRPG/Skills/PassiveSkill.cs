namespace CanrumRPG.Skills
{
    using Enums;

    public abstract class PassiveSkill : Skill
    {
        protected PassiveSkill(int attackModifier, int defenseModifier, int healthModifier, int manaModifier)
            : base(attackModifier, defenseModifier, healthModifier, manaModifier, Skills.Passive)
        {
        }
    }
}