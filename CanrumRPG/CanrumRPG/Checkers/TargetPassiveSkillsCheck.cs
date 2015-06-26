namespace CanrumRPG.Checkers
{
    using Characters;
    using Engine;
    public class TargetPassiveSkillsCheck
    {
        public static void Check(Character hero, Character target,int dmg)
        {
            foreach (var s in target.PassiveSkills)
            {
                int returnDmg;
                switch (s.GetType().Name)
                {
                    case "Hedgehog":
                        returnDmg = dmg * s.AttackModifier / 100;
                        hero.CurrentHealth -= returnDmg;
                        GameEngine.Renderer.WriteLine(
                        string.Format("{0} damage bounces back at {1} beacuse of {2}'s {3}!", returnDmg, hero.Name, target.Name, s.GetType().Name));
                        break;
                }
            }
        }
    }
}
