namespace CanrumRPG.Skills.NPCSkills
{
    using CanrumRPG.Characters;

    public class LastChance : PassiveSkill
    {
        public LastChance() : base(0, 15, 0, 0)
        {
        }

        public override void ApplySkillStats(Character caster)
        {
            int under30 = (caster.CurrentHealth * 30) / 100;
            if (caster.CurrentHealth < under30)
            {
                caster.BlockChance += this.DefenseModifier;
                caster.DefenseRating += this.DefenseModifier / 2;
            }
        }
    }
}
