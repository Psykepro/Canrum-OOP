namespace CanrumRPG.Interfaces
{
    using Enums;

    public interface ISkillModifiers
    {
        int AttackModifier { get; set; }

        int DefenseModifier { get; set; }

        int HealthModifier { get; set; }

        int ManaModifier { get; set; }

        Skills Type { get; set; } 
    }
}