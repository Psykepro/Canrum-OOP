namespace CanrumRPG.Skills.NPCSkills
{
    using CanrumRPG.Characters;

    public class ToughGuy : PassiveSkill
    {
        public ToughGuy() : base(0, 0, 150, 0)
        {
        }

        public override void ApplySkillStats(Character caster)
        {
            caster.MaxHealth += this.HealthModifier;
        }
    }
}
