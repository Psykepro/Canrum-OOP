namespace CanrumRPG.Skills.WarriorSkills
{
    using CanrumRPG.Characters;

    public class UnstopableArmor : PassiveSkill
    {        
        public UnstopableArmor()
            : base(0, 30, 0, 0)
        {
        }

        public override void ApplySkillStats(Character caster)
        {
            caster.BlockChance += this.DefenseModifier;
        }
    }
}
