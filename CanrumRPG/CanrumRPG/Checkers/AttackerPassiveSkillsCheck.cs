namespace CanrumRPG.Checkers
{
    using CanrumRPG.Characters;
    using CanrumRPG.Engine;

    public static class AttackerPassiveSkillsCheck
    {
        public static void Check(Character attacker, Character defender)
        {
            foreach (var s in attacker.PassiveSkills)
            {
                switch (s.GetType().Name)
                {
                    case "Lifesteal":
                        int returnDmg = (attacker.AttackRating * s.HealthModifier) / 100;
                        attacker.CurrentHealth += returnDmg;
                        GameEngine.Renderer.WriteLine(
                        string.Format("{0} steals {1} life from {2}!", attacker.Name, returnDmg, defender.Name));
                        break;
                }
            }
        }
    }
}
