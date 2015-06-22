namespace CanrumRPG.Engine
{
    using System.Collections.Generic;

    using global::CanrumRPG.Skills;
    using global::CanrumRPG.Skills.MageSkills;
    using global::CanrumRPG.Skills.PriestSkills;
    using global::CanrumRPG.Skills.RogueSkills;
    using global::CanrumRPG.Skills.WarriorSkills;

    public static class Resources
    {
        public static readonly Dictionary<int, Skill> MageSkills = new Dictionary<int, Skill>()
                                                                          {
                                                                              { 1, new SharpIce() },
                                                                              { 2, new Torching() },
                                                                              { 3, new ManaSteal() },
                                                                              { 4, new Meteor() },
                                                                              { 5, new Earthquake() }
                                                                          };

        public static readonly Dictionary<int, Skill> PriestSkills = new Dictionary<int, Skill>()
                                                                          {
                                                                              { 1, new Glory() },
                                                                              { 2, new ShadowSteal() },
                                                                              { 3, new BreakArms() },
                                                                              { 4, new ShadowBall() },
                                                                              { 5, new Exhaustion() } 
                                                                          };

        public static readonly Dictionary<int, Skill> RoqueSkills = new Dictionary<int, Skill>() 
                                                                          { 
                                                                              { 1, new Lifesteal() },
                                                                              { 2, new ThrowKnife() },
                                                                              { 3, new Stab() },
                                                                              { 4, new ForTheCrit() },
                                                                              { 5, new SliceSlice() }
                                                                          };

        public static readonly Dictionary<int, Skill> WarriorSkills = new Dictionary<int, Skill>()
                                                                          {
                                                                              { 1, new StrongArms() },
                                                                              { 2, new Armadillo() },
                                                                              { 3, new Hedgehog() },
                                                                              { 4, new Overpower() },
                                                                              { 5, new Cleavage() }
                                                                          };

        public static readonly string[] CharacterNames =
        {
            "Alinar",
            "Zandro",
            "Llombaerth",
            "Inchel",
            "Aymer",
            "Folre",
            "Nyvorlas",
            "Khuumal",
            "Intevar",
            "Nopos"
        };
    }
}