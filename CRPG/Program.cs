using System;

//===== HUDSON BEDWARD 3/11/22 x 3/22/22 x 4/18/22 =====
namespace CRPG
{
    class Program
    {
        private static Player _player = new Player("Booglshpak", 10, 10, 20, 0, 1);


        static void Main(string[] args)
        {
            GameEngine.Initialize();
            _player.MoveTo(World.LocationByID(World.LOCATION_ID_HOME));
            //Console.WriteLine(RandomNumberGenerator.NumberBetween(4, 10));
            InventoryItem sword = new InventoryItem(World.ItemByID(World.ITEM_ID_RUSTY_SWORD), 1);
            InventoryItem club = new InventoryItem(World.ItemByID(World.ITEM_ID_CLUB), 1);
            _player.Inventory.Add(sword);
            //_player.Inventory.Add(club);

            //Gives player Adventurer pass to get past gaurd post
            //InventoryItem aPass = new InventoryItem(World.ItemByID(World.ITEM_ID_ADVENTURER_PASS), 1);
            //_player.Inventory.Add(aPass);


            while (true)
            {
                Console.Write("> ");
                string userInput = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(userInput))
                {
                    continue;
                }
                string cleanedInput = userInput.ToLower();

                if (cleanedInput == "exit")
                {
                    break;
                }
                ParseInput(cleanedInput);

            } //End of WHILE

        } //End of MAIN
        public static void ParseInput(string input)
        {
            if (input.Contains("help"))
            {
                Console.WriteLine("\nHelp is coming soon... be on the look out...");
                //list the commands here if want to, so that it shows from the "help"
            } else if (input.Contains("look"))
            {
                DisplayCurrentLocation();

            } else if (input.Contains("north") || input == "n")
            {
                _player.MoveNorth();
                //{ if the players CurrentLocation = north then show location
                //but if they did not move, don't show location unless they say "look"
                //}
            } else if (input.Contains("east") || input == "e")
            {
                _player.MoveEast();

            } else if (input.Contains("south") || input == "s")
            {
                _player.MoveSouth();

            } else if (input.Contains("west") || input == "w")
            {
                _player.MoveWest();
            } else if (input.Contains("debug"))
            {
                GameEngine.DebugInfo();
            } else if (input == "inventory" || input == "i")
            {
                Console.WriteLine("\n-Current Inventory- ");
                foreach (InventoryItem invItem in _player.Inventory)
                {
                    Console.WriteLine("\t{0} : {1}", invItem.Details.Name, invItem.Quantity);
                }
            } else if (input == "stats")
            {
                Console.WriteLine("\nStats for {0} \n====================", _player.Name);
                Console.WriteLine("Current HP: {0}  (Max HP: {1})", _player.CurrentHitPoints, _player.MaximumHitPoints);
                Console.WriteLine("Level:\t    {0}", _player.Level);

                Console.WriteLine("\nXP:\t    {0}", _player.ExperiencePoints);
                Console.WriteLine("Gold:\t    {0}", _player.Gold);
            } else if (input == "quests" || input == "q")
            {
                if(_player.Quests.Count == 0)
                {
                    Console.WriteLine("You do not have any quests.");
                }
                else
                {
                    foreach (PlayerQuest playerQuest in _player.Quests)
                    {
                        Console.WriteLine("{0}: {1}", playerQuest.Details.Name, playerQuest.IsCompleted ? "Completed" : "Incomplete");
                    }
                }
            }



            else
            {
                Console.WriteLine("\nI do not understand...");
            }
        } //End of ParseInput
        public static void DisplayCurrentLocation()
        {
            Console.WriteLine("\nYou are at: {0}", _player.CurrentLocation.Name);
            if(_player.CurrentLocation.Description != "")
            {
                Console.Write("\t{0}\n", _player.CurrentLocation.Description);
            }

        }


    }
}
