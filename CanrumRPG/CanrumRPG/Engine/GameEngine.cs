namespace CanrumRPG.Engine
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using System.Text.RegularExpressions;

    using CanrumRPG.Attributes;
    using CanrumRPG.Characters;
    using CanrumRPG.Enums;
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

            Renderer.WriteLine("Welcome to Canrum's RPG!");
            Renderer.WriteLine(File.ReadAllText("../../UI/HelpInfo.txt"));

            SetMapSize();
            
            this.player = new Player(GetPlayerName(), GetPlayerRace(), GetPlayerClass());

            this.PopulateEnemies();
            this.PopulateItems();
            
            while (this.IsRunning)
            {
                string[] userInput = Regex.Split(Reader.ReadLine(), @"\s+");

                if (userInput.Length > 2)
                {
                    Renderer.WriteLine("No command has more than one parameter, please re-enter.");
                    continue;
                }

                MapCommands command;

                while (!Enum.TryParse(userInput[0], true, out command))
                {
                    Renderer.WriteLine("Unknown command, please re-enter.");
                    userInput = Regex.Split(Reader.ReadLine(), @"\s+");
                }

                string parameter = "none";

                if (userInput.Length == 2)
                {
                     parameter = userInput[1];
                }
                
                this.ExecuteCommand(command, parameter);

                if (this.creepsList.Count == 0)
                {
                    this.IsRunning = false;
                    Renderer.WriteLine("Congrats! You win!");
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

            foreach (var cl in classInfo.GetFiles())
            {
                Renderer.WriteLine(cl.OpenText().ReadToEnd());
            }

            string choice = Reader.ReadLine();
            CharClass charClass;

            while (!Enum.TryParse(choice, true, out charClass))
            {
                Renderer.WriteLine("Invalid choice of class, please re-enter.");
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

        private static void ExecuteHelpCommand()
        {
            string helpInfo = File.ReadAllText("../../UI/HelpInfo.txt");

            Renderer.WriteLine(helpInfo);
        }

        private void ExecuteCommand(MapCommands command, string parameter)
        {
            switch (command)
            {
                case MapCommands.Help:
                    ExecuteHelpCommand();
                    break;
                case MapCommands.Map:
                    this.PrintMap();
                    break;
                case MapCommands.Left:
                case MapCommands.Right:
                case MapCommands.Up:
                case MapCommands.Down:
                    this.MovePlayer(command);
                    break;
                case MapCommands.Status:
                    this.ShowStatus();
                    break;
                case MapCommands.Clear:
                    Renderer.Clear();
                    break;
                case MapCommands.Exit:
                    this.IsRunning = false;
                    Renderer.WriteLine("Bye, noob!");
                    break;
                case MapCommands.Class:
                    this.ShowClassInfo(parameter);
                    break;
                case MapCommands.Race:
                    this.ShowRaceInfo(parameter);
                    break;
                case MapCommands.Inventory:
                    this.player.ShowInventory();
                    break;
                case MapCommands.Equip:
                    this.player.EquipItem(parameter);
                    break;
            }
        }

        private void ShowRaceInfo(string parameter)
        {
            Race race;
            if (!Enum.TryParse(parameter, true, out race))
            {
                Renderer.WriteLine("This race does not exist, please re-enter.");
            }
            else
            {
                DirectoryInfo raceInfo = new DirectoryInfo(@"..\..\UI\RaceInfo");

                parameter += ".txt";

                foreach (var ra in raceInfo.GetFiles())
                {
                    if (ra.Name.Equals(parameter, StringComparison.OrdinalIgnoreCase))
                    {
                        Renderer.WriteLine(ra.OpenText().ReadToEnd());
                    }
                }
            }
        }

        private void ShowClassInfo(string parameter)
        {
            CharClass charClass;
            if (!Enum.TryParse(parameter, true, out charClass))
            {
                Renderer.WriteLine("This class does not exist, please re-enter.");
            }
            else
            {
                DirectoryInfo classInfo = new DirectoryInfo(@"..\..\UI\ClassInfo");
                DirectoryInfo skillsInfo = new DirectoryInfo(@"..\..\UI\SkillsInfo");

                parameter += ".txt";

                foreach (var cl in classInfo.GetFiles())
                {
                    if (cl.Name.Equals(parameter, StringComparison.OrdinalIgnoreCase))
                    {
                        Renderer.WriteLine(cl.OpenText().ReadToEnd());
                    }
                }

                foreach (var skill in skillsInfo.GetFiles())
                {
                    if (skill.Name.Equals(parameter, StringComparison.OrdinalIgnoreCase))
                    {
                        Renderer.WriteLine(skill.OpenText().ReadToEnd());
                    }
                }
            }
        }

        private void MovePlayer(MapCommands direction)
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
                this.player.Inventory.Add(item);
                this.items.Remove(item);
                item.ItemState = ItemState.Collected;
                Renderer.WriteLine(string.Format("You have found a treasure - {0}!", item));
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
                string[] userInput = Regex.Split(Reader.ReadLine(), @"\s+");
                
                this.ExecuteBattleCommand(userInput, enemy);

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
        
        private void ExecuteBattleCommand(string[] userInput, Character enemy)
        {
            while (userInput.Length > 2)
            {
                Renderer.WriteLine("No command has more than one parameter, please re-enter.");
                userInput = Regex.Split(Reader.ReadLine(), @"\s+");
            }

            BattleCommands command;

            while (!Enum.TryParse(userInput[0], true, out command))
            {
                Renderer.WriteLine("Unknown command, please re-enter.");
                userInput = Regex.Split(Reader.ReadLine(), @"\s+");
            }

            string parameter = "none";

            if (userInput.Length == 2)
            {
                parameter = userInput[1];
            }

            switch (command)
            {
                case BattleCommands.Help:
                    ExecuteHelpCommand();
                    userInput = Regex.Split(Reader.ReadLine(), @"\s+");
                    this.ExecuteBattleCommand(userInput, enemy);
                    break;
                case BattleCommands.Clear:
                    Renderer.Clear();
                    userInput = Regex.Split(Reader.ReadLine(), @"\s+");
                    this.ExecuteBattleCommand(userInput, enemy);
                    break;
                case BattleCommands.Exit:
                    this.IsRunning = false;
                    Renderer.WriteLine("Bye, noob!");
                    Environment.Exit(0);
                    break;
                case BattleCommands.Class:
                    this.ShowClassInfo(parameter);
                    userInput = Regex.Split(Reader.ReadLine(), @"\s+");
                    this.ExecuteBattleCommand(userInput, enemy);
                    break;
                case BattleCommands.Race:
                    this.ShowRaceInfo(parameter);
                    userInput = Regex.Split(Reader.ReadLine(), @"\s+");
                    this.ExecuteBattleCommand(userInput, enemy);
                    break;
                case BattleCommands.Inventory:
                    this.player.ShowInventory();
                    userInput = Regex.Split(Reader.ReadLine(), @"\s+");
                    this.ExecuteBattleCommand(userInput, enemy);
                    break;
                case BattleCommands.Attack:
                    this.player.Attack(enemy, Rand);
                    break;
                case BattleCommands.Uses:
                    this.UsePlayerSkill(parameter.ToLower(), enemy);
                    break;
                case BattleCommands.Usei:
                    this.player.UseItem(parameter.ToLower(), enemy);
                    break;
                case BattleCommands.Enemy:
                    this.ShowEnemyStatus(enemy);
                    userInput = Regex.Split(Reader.ReadLine(), @"\s+");
                    this.ExecuteBattleCommand(userInput, enemy);
                    break;
                case BattleCommands.Status:
                    Renderer.WriteLine(this.player.ToString());
                    userInput = Regex.Split(Reader.ReadLine(), @"\s+");
                    this.ExecuteBattleCommand(userInput, enemy);
                    break;
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

            var treasures = Assembly.GetExecutingAssembly().GetTypes()
                .Where(t => t.IsClass)
                .Where(t => t.CustomAttributes.Any(a => a.AttributeType == typeof(TreasureAttribute)))
                .ToArray();

            var treasure =
                Activator.CreateInstance(treasures[Rand.Next(0, treasures.Length)], new Position(currentX, currentY)) as
                Item;

            return treasure;
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
