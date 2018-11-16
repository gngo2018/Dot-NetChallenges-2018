using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_4
{
    public class ProgramUI
    {
        BadgeRepository _badgeRepo = new BadgeRepository();

        public void Run()
        {
            bool isRunning = true;
            while (isRunning)
            {
                Console.Clear();
                Console.WriteLine("Choose an action:\n" +
                    "1. Create a new badge\n" +
                    "2. Update door access on existing badge\n" +
                    "3. See info of badge and door access");
                int input = int.Parse(Console.ReadLine());
                switch (input)
                {
                    case 1:
                        CreateBadge();
                        break;
                    case 2:
                        UpdateBadge();
                        break;
                    case 3:
                        SeeBadgeInfo();
                        Console.ReadKey();
                        break;
                    default:
                        Console.WriteLine("Uhh try again");
                        Console.ReadLine();
                        break;
                }
            }
        }

        private void CreateBadge()
        {
            Badge newBadge = new Badge();
            Console.WriteLine("What number would you like to associate the badge with? (no # sign needed)");
            newBadge.BadgeID = int.Parse(Console.ReadLine());
            newBadge.Door = AddDoor();

            _badgeRepo.AddBadgeToDictionary(newBadge);
        }

        private List<string> AddDoor()
        {
            var doorList = new List<string>();
            Console.WriteLine("Would you like to add door access to the badge? (y/n)");
            string answer = Console.ReadLine();
            while (answer.Contains("y"))
            {
                Console.WriteLine("What door would you like the badge to access?");
                string accessDoor = Console.ReadLine();
                doorList.Add(accessDoor);

                Console.WriteLine("Would you like to add another door for the badge to access? (y/n)");
                answer = Console.ReadLine();
            }
            return doorList;
        }

        private List<string> NewDoorToBadge()
        {

            var newDoorList = _badgeRepo.AddDoorToBadge();
            Console.WriteLine("Would you like to add more doors to this badge?(y/n)");
            string answer = Console.ReadLine();
            while (answer.Contains("y"))
            {
                Console.WriteLine("What doors would you like to add to the badge?");
                string updateDoor = Console.ReadLine();
                newDoorList.Add(updateDoor);

                Console.WriteLine("Would you like to add another door for the badge to access? (y/n)");
                answer = Console.ReadLine();
            }
            return newDoorList;
        }


        private void UpdateBadge()
        {
            _badgeRepo.GetBadgeDictionary();
            bool isRunning = true;
            while (isRunning)
            {
                Console.WriteLine("How would you like to update the badge?\n" +
                    "1. Add Door Access\n" +
                    "2. Delete a Badge\n" +
                    "3. Return to Main Menu");
                int input = int.Parse(Console.ReadLine());
                switch (input)
                {
                    case 1:
                        SeeBadgeInfo();
                        Console.WriteLine("Which badge would you like to update with the new doors? (Choose corresponding number)");
                        int response = int.Parse(Console.ReadLine());
                        var updateBadge = _badgeRepo.GetBadgeDictionary()[response]; 
                        NewDoorToBadge();
                        break;
                    case 2:
                        SeeBadgeInfo();
                        Console.WriteLine("Please choose the listed item number to remove.");
                        int badgeRemove = int.Parse(Console.ReadLine());
                        _badgeRepo.GetBadgeDictionary().Remove(badgeRemove);
                        break;
                    case 3:
                        isRunning = false;
                        break;
                }
            }
        }

        private void SeeBadgeInfo()
        {
            Console.WriteLine("The current list of registered badges are: ");
            int i = 0;
            foreach (KeyValuePair<int, List<string>> badge in _badgeRepo.GetBadgeDictionary())
            {
                i++;
                Console.WriteLine(i + "." +
                    $"\tBadge ID: {badge.Key}\n" +
                    $"\tDoor Access: { _badgeRepo.PrintOutDoors(badge.Value)} {_badgeRepo.PrintOutUpdateDoors(badge.Value)}\n");
                
            }
        }
    }
}
