namespace CanrumRPG.Characters
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using CanrumRPG.Engine;
    using CanrumRPG.Enums;
    using CanrumRPG.Interfaces;
    using CanrumRPG.Items;
    using CanrumRPG.Skills;

    public class Player : Character, IMoveable
    {
        private Dictionary<int, Skill> skills;
        
        public Player(string name, Race race, CharClass charClass)
            : base(new Position(0, 0), MapMarkers.P, name, race, charClass, true)
        {
            this.Level = 1;
            this.LevelBoundary = 250;
            this.ActiveSkills = new List<ActiveSkill>();
            this.Experience = 0;
            this.skills = new Dictionary<int, Skill>();
            this.InitSkills();
            this.AddSkill();
        }

        public int Level { get; private set; }

        public int Experience { get; private set; }

        public List<ActiveSkill> ActiveSkills { get; private set; }

        private int LevelBoundary { get; set; }
        
        public void SetPlayerPosition(MapCommands direction)
        {
            switch (direction)
            {
                case MapCommands.Up:
                    this.Position = new Position(this.Position.X, this.Position.Y - 1);
                    break;
                case MapCommands.Down:
                    this.Position = new Position(this.Position.X, this.Position.Y + 1);
                    break;
                case MapCommands.Right:
                    this.Position = new Position(this.Position.X + 1, this.Position.Y);
                    break;
                case MapCommands.Left:
                    this.Position = new Position(this.Position.X - 1, this.Position.Y);
                    break;
            }
        }

        public override string ToString()
        {
            return string.Format(
                "{0}: level {9} {1} {2}\nAttack: {3}, Defense: {4}\nHealth: {5}/{6}\nMana: {7}/{8}\nExperience needed for next level: {10}", 
                this.Name, 
                this.Race, 
                this.CharClass, 
                this.AttackRating, 
                this.DefenseRating, 
                this.CurrentHealth, 
                this.MaxHealth, 
                this.CurrentMana,
                this.MaxMana,
                this.Level,
                this.LevelBoundary - this.Experience);
        }

        public void GetPlayerExperience(int expGain)
        {
            this.Experience += expGain;
            if (this.Experience >= this.LevelBoundary)
            {
                this.LevelBoundary *= 2;
                this.Level++;
                this.LevelUp();
            }
        }

        public void ShowInventory()
        {
            if (this.Inventory.Count == 0)
            {
                GameEngine.Renderer.WriteLine("You don't have any items!");
            }

            foreach (var item in this.Inventory)
            {
                GameEngine.Renderer.WriteLine(item.ToString());
            }
        }

        public void EquipItem(string name)
        {
            var items = from item in this.Inventory 
                     where item.Name.Equals(name, StringComparison.OrdinalIgnoreCase) 
                     select item;
            items = items.ToList();

            if (!items.Any())
            {
                GameEngine.Renderer.WriteLine("There's no eqippable item with that name in your inventory!");
                return;
            }

            if (items.Any(i => i.ItemState == ItemState.Equipped))
            {
                GameEngine.Renderer.WriteLine("This item is already equipped!");
            }
            else
            {
                var equipment = (Equipped)items.First();
                equipment.ItemState = ItemState.Equipped;
                equipment.ApplyItemStats(this);
            }
        }

        public void UseItem(string name, Character target)
        {
            var items = from item in this.Inventory
                        where item.Name.Equals(name, StringComparison.OrdinalIgnoreCase)
                        select item;
            items = items.ToList();

            if (!items.Any())
            {
                GameEngine.Renderer.WriteLine("There's no consummable item with that name in your inventory!");
            }
            else
            {
                var potion = (Consumed)items.First();
                potion.DefaultItemAction(this, target);
                this.Inventory.Remove(potion);
            }
        }

        private void InitSkills()
        {
            switch (this.CharClass)
            {
                case CharClass.Mage:
                    this.skills = Resources.MageSkills;
                    break;
                case CharClass.Priest:
                    this.skills = Resources.PriestSkills;
                    break;
                case CharClass.Rogue:
                    this.skills = Resources.RoqueSkills;
                    break;
                case CharClass.Warrior:
                    this.skills = Resources.WarriorSkills;
                    break;
            }
        }

        private void LevelUp()
        {
            GameEngine.Renderer.WriteLine("You have gained a level!");
            this.AddSkill();
            GameEngine.Renderer.WriteLine(string.Format("You now possess the knowledge of {0}", this.skills[this.Level]));
        }
        
        private void AddSkill()
        {
            if (this.skills[this.Level].Type == Skills.Passive)
            {
                this.PassiveSkills.Add(this.skills[this.Level] as PassiveSkill);
                this.PassiveSkills.Last().ApplySkillStats(this);
            }
            else
            {
                this.ActiveSkills.Add(this.skills[this.Level] as ActiveSkill);
            }
        }
    }
}
