namespace CanrumRPG.Engine
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;

    using CanrumRPG.Characters;
    using CanrumRPG.Enums;
    using CanrumRPG.Exceptions;
    using CanrumRPG.Interfaces;
    using CanrumRPG.Items;

    public class GameEngine
    {
        private static readonly Random Rand = new Random();

        private readonly IList<Npc> creepsList;
        private readonly IList<Item> items;

        private int initialNumberOfEnemies;
        private int initialNumberOfTreasures;

        private Player player;

        public GameEngine(IReader reader, IRenderer renderer)
        {
            Reader = reader;
            Renderer = renderer;
            this.creepsList = new List<Npc>();
            this.items = new List<Item>();
        }

        public static int MapWidth { get; private set; }

        public static int MapHeight { get; private set; }

        public static IRenderer Renderer { get; private set; }

        private static IReader Reader { get; set; }

        private bool IsRunning { get; set; }

        public void Run()
        {
            this.IsRunning = true;

            SetMapSize();
            
            this.player = new Player(GetPlayerName(), GetPlayerRace(), GetPlayerClass());

            this.PopulateEnemies();
            this.PopulateItems();

            while (this.IsRunning)
            {
                string command = Reader.ReadLine().ToLower();

                try
                {
                    this.ExecuteCommand(command);
                }
                catch (ObjectOutOfBoundsException ex)
                {
                    Renderer.WriteLine(ex.Message);
                }
                catch (NotEnoughBeerException ex)
                {
                    Renderer.WriteLine(ex.Message);
                }
                catch (Exception ex)
                {
                    Renderer.WriteLine(ex.Message);
                }

                if (this.creepsList.Count == 0)
                {
                    this.IsRunning = false;
                    Renderer.WriteLine("Valar morgulis!");
                }
            }
        }

        private static void SetMapSize()
        {
            int size;
            Renderer.WriteLine("Set map size(choose a number between 10 and 40):");

            while (!int.TryParse(Reader.ReadLine(), out size) || size < 10 || size > 40)
            {
                Renderer.WriteLine("Map size should be a number between 10 and 40. Please, re-enter:");
            }

            MapWidth = size;
            MapHeight = size;
        }

        private static CharClass GetPlayerClass()
        {
            Renderer.WriteLine("Choose a class:");
            DirectoryInfo classInfo = new DirectoryInfo(@"..\..\UI\ClassInfo");
            DirectoryInfo skillInfo = new DirectoryInfo(@"..\..\UI\SkillsInfo");

            foreach (var cl in classInfo.GetFiles())
            {
                Renderer.WriteLine(cl.OpenText().ReadToEnd());
            }

            string choice = Reader.ReadLine();
            CharClass charClass;

            while (!Enum.TryParse(choice, true, out charClass))
            {
                Renderer.WriteLine("Invalid choice of race, please re-enter.");
                choice = Reader.ReadLine();
            }

            return charClass;
        }

        private static Race GetPlayerRace()
        {
            Renderer.WriteLine("Choose a race:");
            DirectoryInfo raceInfo = new DirectoryInfo(@"..\..\UI\RaceInfo");

            foreach (var ra in raceInfo.GetFiles())
            {
                Renderer.WriteLine(ra.OpenText().ReadToEnd());
            }

            string choice = Reader.ReadLine();
            Race race;

            while (!Enum.TryParse(choice, true, out race))
            {
                Renderer.WriteLine("Invalid choice of race, please re-enter.");
                choice = Reader.ReadLine();
            }

            return race;
        }

        private static string GetPlayerName()
        {
            Renderer.WriteLine("Please enter your name:");

            string playerName = Reader.ReadLine();
            while (string.IsNullOrWhiteSpace(playerName))
            {
                Renderer.WriteLine("Player name cannot be empty. Please re-enter.");
                playerName = Reader.ReadLine();
            }

            return playerName;
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
                    this.MovePlayer((MoveDirection)Enum.Parse(typeof(MoveDirection), command, true));
                    break;
                case "status":
                    this.ShowStatus();
                    break;
                case "clear":
                    Renderer.Clear();
                    break;
                case "exit":
                    this.IsRunning = false;
                    Renderer.WriteLine("Bye, noob!");
                    break;
                default:
                    throw new ArgumentException("Unknown command", "command");
            }
        }
        
        private void MovePlayer(MoveDirection direction)
        {
            this.player.SetPlayerPosition(direction);

            Npc enemy =
                this.creepsList
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
                this.items
                .FirstOrDefault(
                    e => e.Position.X == this.player.Position.X 
                        && e.Position.Y == this.player.Position.Y 
                        && e.ItemState == ItemState.Available);

            if (item != null)
            {
                EquipCommand.Equip(item, this.player);
                item.ItemState = ItemState.Collected;
                Renderer.WriteLine("Treasure collected!");
            }
        }

        private void EnterBattle(Npc enemy)
        {
            Renderer.WriteLine(string.Format("You encounter a {0}{1}!", enemy.Race, enemy.CharClass));
            Renderer.WriteLine(string.Format("I'm {0}! I will crush you!", enemy.Name));

            int round = 1;
            while (true)
            {
                Renderer.WriteLine(string.Format("Round {0}", round));
                Renderer.WriteLine("Attack or use skill!");
                string[] command = Regex.Split(Reader.ReadLine(), @"\s+");

                this.ExecuteBattleCommand(command, enemy);

                if (enemy.CurrentHealth <= 0)
                {
                    Renderer.WriteLine("Enemy killed!");
                    this.player.GetPlayerExperience(enemy.MaxHealth);
                    this.creepsList.Remove(enemy);
                    break;
                }

                enemy.Attack(this.player, Rand);

                if (this.player.CurrentHealth <= 0)
                {
                    this.IsRunning = false;
                    Renderer.WriteLine("You're dead!");
                    break;
                }

                round++;
            }
        }
        
        private void ExecuteBattleCommand(string[] command, Character enemy)
        {
            string[] internalCommand = command;
            switch (internalCommand[0])
            {
                case "attack":
                    this.player.Attack(enemy, Rand);
                    break;
                case "use":
                    this.UsePlayerSkill(internalCommand[1].ToLower(), enemy);
                    break;
                case "help":
                    this.ExecuteHelpCommand();
                    internalCommand = Regex.Split(Reader.ReadLine(), @"\s+");
                    this.ExecuteBattleCommand(internalCommand, enemy);
                    break;
                case "enemy":
                    this.ShowEnemyStatus(enemy);
                    internalCommand = Regex.Split(Reader.ReadLine(), @"\s+");
                    this.ExecuteBattleCommand(internalCommand, enemy);
                    break;
                case "status":
                    this.ShowStatus();
                    internalCommand = Regex.Split(Reader.ReadLine(), @"\s+");
                    this.ExecuteBattleCommand(internalCommand, enemy);
                    break;
                case "clear":
                    Renderer.Clear();
                    break;
                case "exit":
                    this.IsRunning = false;
                    Renderer.WriteLine("Bye, noob!");
                    break;
                default:
                    throw new ArgumentException("Unknown command", "command");
            }
        }

        private void ShowStatus()
        {
            Renderer.WriteLine(this.player.ToString());

            Renderer.WriteLine(
                "Number of enemies left: {0}", 
                this.creepsList.Count);
        }

        private void ShowEnemyStatus(Character enemy)
        {
            Renderer.WriteLine(enemy.ToString());
        }

        private void UsePlayerSkill(string skill, Character enemy)
        {
            foreach (var s in this.player.ActiveSkills)
            {
                if (s.GetType().Name.ToLower() == skill)
                {
                    s.Use(this.player, enemy);
                    return;
                }
            }

            Renderer.WriteLine("No such skill available.");
        }

        private void PrintMap()
        {
            StringBuilder sb = new StringBuilder();

            for (int row = 0; row < MapHeight; row++)
            {
                for (int col = 0; col < MapWidth; col++)
                {
                    if (this.player.Position.X == col && this.player.Position.Y == row)
                    {
                        sb.Append(this.player.MapMarker);
                        continue;
                    }

                    var character =
                         this.creepsList
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

            Renderer.WriteLine(sb.ToString());
        }

        private void ExecuteHelpCommand()
        {
            string helpInfo = File.ReadAllText("../../UI/HelpInfo.txt");

            Renderer.WriteLine(helpInfo);
        }

        private void PopulateItems()
        {
            this.initialNumberOfTreasures = MapWidth * MapHeight * 15 / 100;
            for (int i = 0; i < this.initialNumberOfTreasures; i++)
            {
                Item item = this.CreateItem();
                this.items.Add(item);
            }
        }

        private Item CreateItem()
        {
            int currentX = Rand.Next(1, MapWidth);
            int currentY = Rand.Next(1, MapHeight);

            bool containsEnemy = this.creepsList
                .Any(e => e.Position.X == currentX && e.Position.Y == currentY);

            bool containsItem = this.items
                .Any(e => e.Position.X == currentX && e.Position.Y == currentY);

            while (containsEnemy || containsItem)
            {
                currentX = Rand.Next(1, MapWidth);
                currentY = Rand.Next(1, MapHeight);

                containsEnemy = this.creepsList
                .Any(e => e.Position.X == currentX && e.Position.Y == currentY);

                containsItem = this.items
                .Any(e => e.Position.X == currentX && e.Position.Y == currentY);
            }

            return new Item(new Position(currentX, currentY), "some item", Rand.Next(20), Rand.Next(20), Rand.Next(20), Rand.Next(20), Skills.Passive);
        }

        private void PopulateEnemies()
        {
            this.initialNumberOfEnemies = MapHeight * MapWidth * 15 / 100;
            for (int i = 0; i < this.initialNumberOfEnemies; i++)
            {
                Npc enemy = this.CreateEnemy();
                this.creepsList.Add(enemy);
            }
        }

        private Npc CreateEnemy()
        {
            int currentX = Rand.Next(1, MapWidth);
            int currentY = Rand.Next(1, MapHeight);

            bool containsEnemy = this.creepsList
                .Any(e => e.Position.X == currentX && e.Position.Y == currentY);

            while (containsEnemy)
            {
                currentX = Rand.Next(1, MapWidth);
                currentY = Rand.Next(1, MapHeight);

                containsEnemy = this.creepsList
                .Any(e => e.Position.X == currentX && e.Position.Y == currentY);
            }

            int nameIndex = Rand.Next(0, Resources.CharacterNames.Length);
            string name = Resources.CharacterNames[nameIndex];

            Npc creep = new Npc(new Position(currentX, currentY), name, (Race)Rand.Next(5), (CharClass)Rand.Next(4), Rand);

            return creep;
        }
    }
}
