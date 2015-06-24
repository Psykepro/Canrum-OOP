


namespace CanrumRPG.Skills.WarriorSkills
{
    using Characters;

    using Enums;

    class UnstopableArmor : PassiveSkill
    {        
        public UnstopableArmor()
            : base(0, 30, 0, 0, CharClass.Warrior)
        {
        }

        public override void ApplySkillStats(Character caster)
        {
            caster.BlockChance += this.DefenseModifier;
        }
    }
}
