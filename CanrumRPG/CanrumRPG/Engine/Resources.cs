namespace CanrumRPG.Engine
{
    using System.Collections.Generic;

    using CanrumRPG.Items;
    using CanrumRPG.Items.Equippable;
    using CanrumRPG.Skills;
    using CanrumRPG.Skills.MageSkills;
    using CanrumRPG.Skills.NPCSkills;
    using CanrumRPG.Skills.PriestSkills;
    using CanrumRPG.Skills.RogueSkills;
    using CanrumRPG.Skills.WarriorSkills;

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
                                                                              { 5, new SliceSliceSlice() }
                                                                          };

        public static readonly Dictionary<int, Skill> WarriorSkills = new Dictionary<int, Skill>()
                                                                          {
                                                                              { 1, new StrongArms() }, 
                                                                              { 2, new Armadillo() }, 
                                                                              { 3, new Hedgehog() }, 
                                                                              { 4, new UnstopableArmor() }, 
                                                                              { 5, new Cleavage() }
                                                                          };

        public static readonly List<Skill> NpcSkills = new List<Skill>()
                                                           {
                                                               new BocBoc(), 
                                                               new Claw(), 
                                                               new LastChance(), 
                                                               new StoneSkin(), 
                                                               new ToughGuy()
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