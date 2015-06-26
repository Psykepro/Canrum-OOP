using CanrumRPG.Engine;

namespace CanrumRPG.Checkers
{
    using Characters;
    public class AttackerPassiveSkillsCheck
    {
        public static void Check(Character attackingHero,Character target)
        {
            foreach (var s in attackingHero.PassiveSkills)
            {
                switch (s.GetType().Name)
                {
                    case "Lifesteal":
                        int returnDmg = (attackingHero.AttackRating * s.HealthModifier) / 100;
                        attackingHero.CurrentHealth += returnDmg;
                        GameEngine.Renderer.WriteLine(
                        string.Format("{0} steals {1} life from {2}!", attackingHero.Name, returnDmg, target.Name));
                        break;
                }
            }
        }
    }
}
