﻿namespace CanrumRPG.Engine
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Text;

    using Attributes;

    using Characters;

    using Enums;

    using Exceptions;

    using Interfaces;

    using Items;

    public class GameEngine
    {
        private static readonly Random Rand = new Random();

        private readonly IReader reader;
        private readonly IRenderer renderer;

        private readonly string[] characterNames =
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

        private readonly IList<GameObject> characters;
        private readonly IList<GameObject> items;

        private int initialNumberOfEnemies;
        private int initialNumberOfTreasures;

        private Player player;

        public GameEngine(IReader reader, IRenderer renderer)
        {
            this.reader = reader;
            this.renderer = renderer;
            this.characters = new List<GameObject>();
            this.items = new List<GameObject>();
        }

        public static int MapWidth { get; set; }

        public static int MapHeight { get; set; }

        public bool IsRunning { get; private set; }

        public void Run()
        {
            this.IsRunning = true;

            this.SetMapSize();

            var playerName = this.GetPlayerName();
            Race race = this.GetPlayerRace();
            CharClass charClass = this.GetPlayerClass();

            this.player = new Player(playerName, race, charClass);

            this.PopulateEnemies();
            this.PopulateItems();

            while (this.IsRunning)
            {
                string command = this.reader.ReadLine();

                try
                {
                    this.ExecuteCommand(command);
                }
                catch (ObjectOutOfBoundsException ex)
                {
                    this.renderer.WriteLine(ex.Message);
                }
                catch (NotEnoughBeerException ex)
                {
                    this.renderer.WriteLine(ex.Message);
                }
                catch (Exception ex)
                {
                    this.renderer.WriteLine(ex.Message);
                }

                if (this.characters.Count == 0)
                {
                    this.IsRunning = false;
                    this.renderer.WriteLine("Valar morgulis!");
                }
            }
        }

        private void SetMapSize()
        {
            int size;
            this.renderer.WriteLine("Set map size(choose a number between 10 and 40):");
            bool success = int.TryParse(this.reader.ReadLine(), out size);

            while (!success)
            {
                this.renderer.WriteLine("Map size should be a number between 10 and 40. Please, re-enter:");
                success = int.TryParse(this.reader.ReadLine(), out size);
            }

            GameEngine.MapWidth = size;
            GameEngine.MapHeight = size;
        }

        private void ExecuteCommand(string command)
        {
            switch (command)
            {
                case "help":
                    this.ExecuteHelpCommand();
                    break;
                case "map":
                    this.PrintMap();
                    break;
                case "left":
                case "right":
                case "up":
                case "down":
                    this.MovePlayer(command);
                    break;
                case "status":
                    this.ShowStatus();
                    break;
                case "clear":
                    this.renderer.Clear();
                    break;
                case "exit":
                    this.IsRunning = false;
                    this.renderer.WriteLine("Bye, noob!");
                    break;
                default:
                    throw new ArgumentException("Unknown command", "command");
            }
        }

        private void ShowStatus()
        {
            this.renderer.WriteLine(this.player.ToString());

            this.renderer.WriteLine(
                "Number of enemies left: {0}", 
                this.characters.Count);
        }

        private void MovePlayer(string command)
        {
            this.player.Move(command);

            Character enemy =
                this.characters.Cast<Character>()
                .FirstOrDefault(
                    e => e.Position.X == this.player.Position.X 
                        && e.Position.Y == this.player.Position.Y 
                        && e.CurrentHealth > 0);

            if (enemy != null)
            {
                this.EnterBattle(enemy);
                return;
            }

            Item item =
                this.items.Cast<Item>()
                .FirstOrDefault(
                    e => e.Position.X == this.player.Position.X 
                        && e.Position.Y == this.player.Position.Y 
                        && e.ItemState == ItemState.Available);

            if (item != null)
            {
                this.player.Inventory.Add(item);
                item.ItemState = ItemState.Collected;
                this.renderer.WriteLine("Treasure collected!");
            }
        }

        private void EnterBattle(Character enemy)
        {
            this.renderer.WriteLine(string.Format("You encounter a {0}{1}!", enemy.Race, enemy.CharClass));
            this.renderer.WriteLine(string.Format("I'm {0}! I will crush you!", enemy.Name));

            int round = 1;
            while (true)
            {
                this.renderer.WriteLine(string.Format("Round {0}", round));
                this.renderer.WriteLine("Attack or use skill!");
                string command = this.reader.ReadLine();

                this.ExecuteBattleCommand(command, enemy);

                if (enemy.CurrentHealth <= 0)
                {
                    this.renderer.WriteLine("Enemy killed!");
                    this.characters.Remove(enemy);
                    break;
                }

                enemy.Attack(this.player, Rand);

                if (this.player.CurrentHealth <= 0)
                {
                    this.IsRunning = false;
                    this.renderer.WriteLine("You're dead!");
                    break;
                }

                round++;
            }
            
        }

        private void ExecuteBattleCommand(string command, Character enemy)
        {
            switch (command)
            {
                case "attack":
                    this.player.Attack(enemy, Rand);
                    break;
                default:
                    throw new ArgumentException("Unknown command", "command");
            }
        }

        private void PrintMap()
        {
            StringBuilder sb = new StringBuilder();

            for (int row = 0; row < GameEngine.MapHeight; row++)
            {
                for (int col = 0; col < GameEngine.MapWidth; col++)
                {
                    if (this.player.Position.X == col && this.player.Position.Y == row)
                    {
                        sb.Append(this.player.MapMarker);
                        continue;
                    }

                    var character =
                         this.characters
                         .Cast<Character>()
                         .FirstOrDefault(c => c.Position.X == col 
                             && c.Position.Y == row 
                             && c.CurrentHealth > 0);

                    var item = this.items
                        .Cast<Item>()
                        .FirstOrDefault(c => c.Position.X == col 
                            && c.Position.Y == row 
                            && c.ItemState == ItemState.Available);

                    if (character == null && item == null)
                    {
                        sb.Append('.');
                    }
                    else if (character != null)
                    {
                        var ch = (GameObject)character;
                        sb.Append(ch.MapMarker);
                    }
                    else
                    {
                        sb.Append(item.MapMarker);
                    }
                }

                sb.AppendLine();
            }

            this.renderer.WriteLine(sb.ToString());
        }

        private void ExecuteHelpCommand()
        {
            string helpInfo = File.ReadAllText("../../HelpInfo.txt");

            this.renderer.WriteLine(helpInfo);
        }

        private CharClass GetPlayerClass()
        {
            this.renderer.WriteLine("Choose a class:");
            this.renderer.WriteLine("Mage (+50% Maximum mana, +100% Critical strike chance)");
            this.renderer.WriteLine("Priest (+50% Maximum mana, +50% Maximum health)");
            this.renderer.WriteLine("Rogue (+50% Attack rating, +100% Critical strike chance)");
            this.renderer.WriteLine("Warrior (+50% Defense rating, +100% Block chance)");

            string choice = this.reader.ReadLine();

            string[] validChoices = { "Mage", "Priest", "Rogue", "Warrior" };

            while (!validChoices.Contains(choice))
            {
                this.renderer.WriteLine("Invalid choice of race, please re-enter.");
                choice = this.reader.ReadLine();
            }

            CharClass charClass;
            Enum.TryParse(choice, true, out charClass);

            return charClass;
        }

        private Race GetPlayerRace()
        {
            this.renderer.WriteLine("Choose a race:");
            this.renderer.WriteLine("Elf (+50% Attack rating)");
            this.renderer.WriteLine("Orc (+50% Maximum health)");
            this.renderer.WriteLine("Human (+100% Critical strike chance)");
            this.renderer.WriteLine("Undead (+50% Maximum mana)");
            this.renderer.WriteLine("Goblin (+50% Defense rating)");

            string choice = this.reader.ReadLine();

            string[] validChoices = { "Elf", "Orc", "Human", "Undead", "Goblin" };

            while (!validChoices.Contains(choice))
            {
                this.renderer.WriteLine("Invalid choice of race, please re-enter.");
                choice = this.reader.ReadLine();
            }

            Race race;
            Enum.TryParse(choice, true, out race);

            return race;
        }

        private string GetPlayerName()
        {
            this.renderer.WriteLine("Please enter your name:");

            string playerName = this.reader.ReadLine();
            while (string.IsNullOrWhiteSpace(playerName))
            {
                this.renderer.WriteLine("Player name cannot be empty. Please re-enter.");
                playerName = this.reader.ReadLine();
            }

            return playerName;
        }

        private void PopulateItems()
        {
            this.initialNumberOfTreasures = GameEngine.MapWidth * GameEngine.MapHeight * 15 / 100;
            for (int i = 0; i < this.initialNumberOfTreasures; i++)
            {
                Item item = this.CreateItem();
                this.items.Add(item);
            }
        }

        private Item CreateItem()
        {
            int currentX = Rand.Next(1, GameEngine.MapWidth);
            int currentY = Rand.Next(1, GameEngine.MapHeight);

            bool containsEnemy = this.characters
                .Any(e => e.Position.X == currentX && e.Position.Y == currentY);

            bool containsItem = this.items
                .Any(e => e.Position.X == currentX && e.Position.Y == currentY);

            while (containsEnemy || containsItem)
            {
                currentX = Rand.Next(1, GameEngine.MapWidth);
                currentY = Rand.Next(1, GameEngine.MapHeight);

                containsEnemy = this.characters
                .Any(e => e.Position.X == currentX && e.Position.Y == currentY);

                containsItem = this.items
                .Any(e => e.Position.X == currentX && e.Position.Y == currentY);
            }

            return new Item(new Position(currentX, currentY), "some item", Rand.Next(20), Rand.Next(20), Rand.Next(20), Rand.Next(20), Skills.Passive);
        }

        private void PopulateEnemies()
        {
            this.initialNumberOfEnemies = GameEngine.MapHeight * GameEngine.MapWidth * 15 / 100;
            for (int i = 0; i < this.initialNumberOfEnemies; i++)
            {
                GameObject enemy = this.CreateEnemy();
                this.characters.Add(enemy);
            }
        }

        private GameObject CreateEnemy()
        {
            int currentX = Rand.Next(1, GameEngine.MapWidth);
            int currentY = Rand.Next(1, GameEngine.MapHeight);

            bool containsEnemy = this.characters
                .Any(e => e.Position.X == currentX && e.Position.Y == currentY);

            while (containsEnemy)
            {
                currentX = Rand.Next(1, GameEngine.MapWidth);
                currentY = Rand.Next(1, GameEngine.MapHeight);

                containsEnemy = this.characters
                .Any(e => e.Position.X == currentX && e.Position.Y == currentY);
            }

            int nameIndex = Rand.Next(0, this.characterNames.Length);
            string name = this.characterNames[nameIndex];

            var enemyTypes = Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(t => t.CustomAttributes
                    .Any(a => a.AttributeType == typeof(EnemyAttribute)))
                    .ToArray();

            var type = enemyTypes[Rand.Next(0, enemyTypes.Length)];

            GameObject character = Activator
                .CreateInstance(type, new Position(currentX, currentY), name) as GameObject;

            return character;
        }
    }
}
