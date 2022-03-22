using System;
using System.Collections.Generic;
using System.Text;

namespace CRPG
{
    public class World
    {
        public static readonly string WorldName = "Anndorus";
        public static readonly List<Location> Locations = new List<Location>();

        //Start providing IDs for locations
        public const int LOCATION_ID_HOME = 1;
        public const int LOCATION_ID_FOREST_PATH = 2;
        public const int LOCATION_ID_VILLAGE = 3;

        //Constructor for the World
        static World()
        {
            PopulateLocations();
        }

        private static void PopulateLocations()
        {
            //Create the location objects
            Location home = new Location(LOCATION_ID_HOME, "Home", 
                "Your home is in the base of a tall tree...");
            Location forestPath = new Location(LOCATION_ID_FOREST_PATH, "Forest Path",
                "A path that leads through the thick Annaplous tree forest...");
            Location village = new Location(LOCATION_ID_VILLAGE, "Village",
                "A large village near the water with a massive harvest of Annaples...");

            //Link the locations together
            home.LocationToNorth = forestPath;
            forestPath.LocationToEast = village;
            village.LocationToWest = forestPath;
            forestPath.LocationToSouth = home;

            //Create our list of locations
            Locations.Add(home);
            Locations.Add(forestPath);
            Locations.Add(village);
        }
        public static Location LocationByID(int id)
        {
            foreach (Location loc in Locations)
            {
                if(loc.ID == id)
                {
                    return loc;
                }
            }
            return null;
        }


        public static void ListLocations()
        {
            Console.WriteLine("These are the locations in the world: ");
            foreach (Location loc in Locations)
            {
                Console.WriteLine("\t{0}", loc.Name);
            }
        }

    }
}
