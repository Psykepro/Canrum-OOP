namespace CanrumRPG.Characters
{
    using System;
    using System.Collections.Generic;

    using Engine;

    using Enums;

    using Interfaces;

    using Items;

    public class Player : Character, IMoveable
    {
        private readonly List<Skills> passiveSkills;

        private readonly List<Skills> activeSkills;

        public Player(string name, Race race, CharClass charClass)
            : base(new Position(0, 0), MapMarkers.P, name, race, charClass, true)
        {
            this.passiveSkills = new List<Skills>();
            this.activeSkills = new List<Skills>();
            this.FillInventory();
            this.SetPassiveSkills();
            this.SetActiveSkills();
        }

        public void Move(string direction)
        {
            switch (direction)
            {
                case "up":
                    this.Position = new Position(this.Position.X, this.Position.Y - 1);
                    break;
                case "down":
                    this.Position = new Position(this.Position.X, this.Position.Y + 1);
                    break;
                case "right":
                    this.Position = new Position(this.Position.X + 1, this.Position.Y);
                    break;
                case "left":
                    this.Position = new Position(this.Position.X - 1, this.Position.Y);
                    break;
                default:
                    throw new ArgumentException("Invalid direction.", "direction");
            }
        }

        public override string ToString()
        {
            return string.Format("Player {0}", this.Name);
        }

        private void SetActiveSkills()
        {
            throw new NotImplementedException();
        }

        private void SetPassiveSkills()
        {
            this.SetPassiveSkills();
        }

        private void FillInventory()
        {
            throw new NotImplementedException();
        }
    }
}
