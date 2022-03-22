using System;
using System.Collections.Generic;
using System.Text;

namespace CRPG
{
    public static class GameEngine
    {
        public static string Version = "0.0.1";
        public static void Initialize()
        {
            Console.WriteLine("Initializing Game Engine Version {0}", Version);
            Console.WriteLine("\n\n-=- Behold! The World of {0} Lies before Your very Eyes! -=-", World.WorldName);
            Console.WriteLine();
            World.ListLocations();



        }



    }
}
