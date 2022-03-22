using System;
using System.Collections.Generic;
using System.Text;

namespace CRPG
{
    public class Player
    {
     //"protected" allows you to have variables that aren't available outside the project. So as long as you're in the project, a "protected" is protected.
        public string Name { set; get; }
        public Location CurrentLocation { set; get; }

        public void MoveTo(Location loc)
        {
            CurrentLocation = loc;
        }

        public void MoveNorth()
        {
            if (CurrentLocation.LocationToNorth != null)
            {
                MoveTo(CurrentLocation.LocationToNorth);
            } else
            {
                Console.WriteLine("You cannot move North.");
            }
        }
        public void MoveEast()
        {
            if (CurrentLocation.LocationToEast != null)
            {
                MoveTo(CurrentLocation.LocationToEast);
            }
            else
            {
                Console.WriteLine("You cannot move East.");
            }
        }
        public void MoveSouth()
        {
            if (CurrentLocation.LocationToSouth != null)
            {
                MoveTo(CurrentLocation.LocationToSouth);
            }
            else
            {
                Console.WriteLine("You cannot move South.");
            }
        }
        public void MoveWest()
        {
            if (CurrentLocation.LocationToWest != null)
            {
                MoveTo(CurrentLocation.LocationToWest);
            }
            else
            {
                Console.WriteLine("You cannot move West.");
            }
        }


    } //End of class Player
}
