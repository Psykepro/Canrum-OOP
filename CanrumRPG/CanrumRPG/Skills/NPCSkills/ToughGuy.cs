namespace CanrumRPG.Skills.NPCSkills
{
    using Characters;

    using Enums;

    public class ToughGuy:PassiveSkill
    {
        public ToughGuy(CharClass charClass) : base(0, 0, 150, 0, charClass)
        {
        }

        public override void ApplySkillStats(Character caster)
        {
            caster.MaxHealth += this.HealthModifier;
        }
    }
}
