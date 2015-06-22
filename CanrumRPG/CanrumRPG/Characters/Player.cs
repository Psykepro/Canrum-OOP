namespace CanrumRPG.Characters
{
    using System.Collections.Generic;
    using System.Linq;

    using Engine;

    using Enums;

    using Interfaces;

    using Items;

    using Skills;



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
            this.FillInventory();
        }

        public int Level { get; private set; }

        public int Experience { get; private set; }

        public List<ActiveSkill> ActiveSkills { get; private set; }

        private int LevelBoundary { get; set; }
        
        public void SetPlayerPosition(MoveDirection direction)
        {
            switch (direction)
            {
                case MoveDirection.Up:
                    this.Position = new Position(this.Position.X, this.Position.Y - 1);
                    break;
                case MoveDirection.Down:
                    this.Position = new Position(this.Position.X, this.Position.Y + 1);
                    break;
                case MoveDirection.Right:
                    this.Position = new Position(this.Position.X + 1, this.Position.Y);
                    break;
                case MoveDirection.Left:
                    this.Position = new Position(this.Position.X - 1, this.Position.Y);
                    break;
            }
        }

        public override string ToString()
        {
            return string.Format(
                "{0}: {1} {2} {9}\nAttack: {3}, Defense: {4}\nHealth: {5}/{6}\nMana: {7}/{8}",
                this.Name,
                this.Race,
                this.CharClass,
                this.AttackRating,
                this.DefenseRating,
                this.CurrentHealth,
                this.MaxHealth,
                this.CurrentMana,
                this.MaxMana,
                this.Level);
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

        private void FillInventory()
        {
            // TODO;
        }
    }
}
