namespace CanrumRPG.Checkers
{
    using CanrumRPG.Characters;
    using CanrumRPG.Engine;

    public static class TargetPassiveSkillsCheck
    {
        public static void Check(Character attacker, Character defender, int dmg)
        {
            foreach (var s in defender.PassiveSkills)
            {
                switch (s.GetType().Name)
                {
                    case "Hedgehog":
                        int returnDmg = dmg * s.AttackModifier / 100;
                        attacker.CurrentHealth -= returnDmg;
                        GameEngine.Renderer.WriteLine(
                        string.Format("{0} damage bounces back at {1} beacuse of {2}'s {3}!", returnDmg, attacker.Name, defender.Name, s.GetType().Name));
                        break;
                }
            }
        }
    }
}
