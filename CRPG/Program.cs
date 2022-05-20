using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


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
            } else if (input == "stats" || input == "!")
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
            } else if (input.Contains("attack") || input == "a")
            {
                if(_player.CurrentLocation.MonsterLivingHere == null)
                {
                    Console.WriteLine("There is nothing here to attack.");
                }
                else
                {
                    if(_player.CurrentWeapon == null)
                    {
                        Console.WriteLine("You are not equipped with a weapon! You must use your bare hands!");
                    }
                    else
                    {
                        _player.UseWeapon(_player.CurrentWeapon);
                    }

                }
            }else if (input.StartsWith("equip "))
            {
                _player.UpdateWeapons();
                string inputWeaponName = input.Substring(6).Trim();
                if (string.IsNullOrEmpty(inputWeaponName))
                {
                    Console.WriteLine("You must enter the name of thy weapon to equip, my good sir.");
                }
                else
                {
                    Weapon weaponToEquip = _player.Weapons.SingleOrDefault (x => x.Name.ToLower() == inputWeaponName
                   || x.NamePlural.ToLower() == inputWeaponName);
                    if(weaponToEquip == null)
                    {
                        Console.WriteLine("You do not have the weapon {0}!", inputWeaponName);
                    }else
                    {
                        _player.CurrentWeapon = weaponToEquip;
                        Console.WriteLine("You equip your {0}...", _player.CurrentWeapon.Name);
                    }

                }
            }else if (input == "weapons")
            {
                _player.UpdateWeapons();
                Console.WriteLine("List of Weapons");
                foreach (Weapon w in _player.Weapons)
                {
                    Console.WriteLine("\t{0}", w.Name);
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
