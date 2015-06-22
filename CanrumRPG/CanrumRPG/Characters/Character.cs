namespace CanrumRPG.Characters
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Engine;

    using Enums;

    using Interfaces;

    using Items;

    using Skills;
    using Skills.WarriorSkills;

    public abstract class Character : GameObject, ICharacter
    {
        private const int Ar = 100;

        private const int Dr = 50;

        private const int Cc = 5;

        private const int Bc = 5;

        private const int Mh = 100;

        private const int Mm = 100;

        private readonly bool isPlayer;

        protected Character(Position position, MapMarkers mapMarker, string name, Race race, CharClass charClass, bool isPlayer)
            : base(position, mapMarker, name)
        {
            this.isPlayer = isPlayer;
            this.Race = race;
            this.CharClass = charClass;
            this.SetInitialStats(this.Race, this.CharClass, this.isPlayer);
            this.PassiveSkills = new List<PassiveSkill>();
            this.Inventory = new List<Item>();
        }

        public int AttackRating { get; set; }

        public int DefenseRating { get; set; }

        public int CritChance { get; set; }

        public int BlockChance { get; set; }

        public int MaxHealth { get; set; }

        public int CurrentHealth { get; set; }

        public int MaxMana { get; set; }

        public int CurrentMana { get; set; }

        public List<Item> Inventory { get; set; }

        public CharClass CharClass { get; private set; }

        public Race Race { get; private set; }

        public List<PassiveSkill> PassiveSkills { get; private set; }

        public void Attack(Character target, Random rnd)
        {
            int crit = rnd.Next(1, 101);
            int block = rnd.Next(1, 101);

            if (block > target.BlockChance)
            {
                int dmg = this.AttackRating - target.DefenseRating;

                if (crit <= this.CritChance)
                {
                    dmg *= 2;
                    GameEngine.Renderer.WriteLine(
                        string.Format("{0} lands a critical strike on {1} for {2} damage!", this.Name, target.Name, dmg));
                }
                else
                {
                    GameEngine.Renderer.WriteLine(
                        string.Format("{0} hits {1} for {2} damage!", this.Name, target.Name, dmg));
                }

                target.CurrentHealth -= dmg;

                foreach (var s in target.PassiveSkills)
                {
                    int returnDmg;
                    switch (s.GetType().Name)
                    {
                        case "Hedgehog":
                            returnDmg = dmg * s.AttackModifier / 100;
                            this.CurrentHealth -= returnDmg;
                            GameEngine.Renderer.WriteLine(
                            string.Format("{0} damage bounces back at {1} beacuse of {2}'s {3}!", returnDmg, this.Name, target.Name, s.GetType().Name));
                            break;
                        case "Lifesteal":
                            returnDmg = (target.AttackRating * s.HealthModifier) / 100;
                            target.CurrentHealth += returnDmg;
                            GameEngine.Renderer.WriteLine(
                            string.Format("{0} steals {1} life from {2}!", target.Name, returnDmg, this.Name));
                            break;
                    }
                }

                foreach (var s in this.PassiveSkills)
                {
                    switch (s.GetType().Name)
                    {
                        case "Lifesteal":
                            int returnDmg = (this.AttackRating * s.HealthModifier) / 100;
                            this.CurrentHealth += returnDmg;
                            GameEngine.Renderer.WriteLine(
                            string.Format("{0} steals {1} life from {2}!", this.Name, returnDmg, target.Name));
                            break;
                    }
                }

            }
            else
            {
                GameEngine.Renderer.WriteLine(string.Format("{0} blocks {1}'s attack!", target.Name, this.Name));
            }
        }

        public override string ToString()
        {
            return string.Format(
                "{0}: {1} {2}\nAttack: {3}, Defense: {4}\nHealth: {5}/{6}\nMana: {7}/{8}",
                this.Name,
                this.Race,
                this.CharClass,
                this.AttackRating,
                this.DefenseRating,
                this.CurrentHealth,
                this.MaxHealth,
                this.CurrentMana,
                this.MaxMana);
        }

        private void SetInitialStats(Race race, CharClass charClass, bool player)
        {
            if (player)
            {
                this.AttackRating = Ar;
                this.DefenseRating = Dr;
                this.CritChance = Cc;
                this.BlockChance = Bc;
                this.MaxHealth = Mh;
                this.MaxMana = Mm;
            }
            else
            {
                this.AttackRating -= Ar / 8;
                this.DefenseRating -= Dr / 8;
                this.CritChance -= Cc / 8;
                this.BlockChance -= Bc / 8;
                this.MaxHealth -= Mh / 8;
                this.MaxMana -= Mm / 8;
            }

            switch (race)
            {
                case Race.Elf:
                    this.AttackRating += Ar / 2;
                    break;
                case Race.Orc:
                    this.MaxHealth += Mh / 2;
                    break;
                case Race.Human:
                    this.CritChance *= 2;
                    break;
                case Race.Undead:
                    this.MaxMana += Mm / 2;
                    break;
                case Race.Goblin:
                    this.DefenseRating += Dr / 2;
                    break;
            }

            switch (charClass)
            {
                case CharClass.Mage:
                    this.MaxMana += Mm / 2;
                    this.CritChance *= 2;
                    break;
                case CharClass.Priest:
                    this.MaxMana += Mm / 2;
                    this.MaxHealth += Mh / 2;
                    break;
                case CharClass.Rogue:
                    this.CritChance *= 2;
                    this.AttackRating += Ar / 2;
                    break;
                case CharClass.Warrior:
                    this.DefenseRating += Dr / 2;
                    this.BlockChance *= 2;
                    break;
            }

            this.CurrentHealth = this.MaxHealth;
            this.CurrentMana = this.MaxMana;
        }
    }
}
