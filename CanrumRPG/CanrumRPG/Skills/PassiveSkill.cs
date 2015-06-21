namespace CanrumRPG.Skills
{
    using Characters;

    using Enums;

    public abstract class PassiveSkill : Skill
    {
        protected PassiveSkill(int attackModifier, int defenseModifier, int healthModifier, int manaModifier, CharClass charClass)
            : base(attackModifier, defenseModifier, healthModifier, manaModifier, Skills.Passive, charClass)
        {
        }

        protected abstract void ApplySkillStats(Character caster);
    }
}