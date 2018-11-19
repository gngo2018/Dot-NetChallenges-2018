using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_4
{
    public class BadgeRepository
    {
        Dictionary<int, List<string>> _badgeDictionary = new Dictionary<int, List<string>>();

        public void AddBadgeToDictionary(Badge badge)
        {
            _badgeDictionary.Add(badge.BadgeID, badge.Door);
        }

        public Dictionary<int, List<string>> GetBadgeDictionary()
        {
            return _badgeDictionary;
        }

        public string PrintOutDoors(List<string> accessDoors)
        {
            string printedDoors = "";

            foreach (string accessDoor in accessDoors)
            {
                printedDoors = accessDoor + ", " + printedDoors;
            }
            return printedDoors;
        }

        //This is where I got lost for updating the doors. Really lost for replacing only the value part of a dictionary. SOS
        public void AddDoorToBadge(Badge badge, string door)
        {
           var newDoorList = _badgeDictionary[badge.BadgeID];
        }
    }
}
