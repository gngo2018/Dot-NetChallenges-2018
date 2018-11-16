using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_3
{
    public class ProgramUI
    {
        OutingRepository _outingRepo = new OutingRepository();

        public void Run()
        {
            RunMenu();
        }

        private void RunMenu()
        {
            bool isRunning = true;
            while (isRunning)
            {
                Console.Clear();
                Console.WriteLine("Please Choose an Action\n" +
                    "1. Display List of Outings\n" +
                    "2. Add Outings to List\n" +
                    "3. Calculated Costs");
                int input = int.Parse(Console.ReadLine());
                switch (input)
                {
                    case 1:
                        DisplayList();
                        Console.WriteLine("Press any key to continue!");
                        Console.ReadKey();
                        break;
                    case 2:
                        AddOuting();
                        break;
                    case 3:
                        Calculation();
                        Console.WriteLine("Press any key to continue!");
                        Console.ReadKey();
                        break;
                    default:
                        Console.WriteLine("Uhh try again");
                        Console.ReadLine();
                        break;
                }
            }
        }

        private void DisplayList()
        {
            Console.WriteLine("The current list of outings registered include: ");
            foreach (Outing outing in _outingRepo.GetOutingList())
            {
                Console.WriteLine(
                    $"Event Type: {outing.EventType}\n" +
                    $"Attendance: {outing.Attendance}\n" +
                    $"Date = {outing.Date.ToShortDateString()}\n" +
                    $"Total Cost = {outing.TotalCost}\n" +
                    $"Cost Per Person = {outing.CostPerPerson}");
            }
        }

        private void AddOuting()
        {
            Outing newOuting = new Outing();
            Console.WriteLine("Which event are you wanting to add: \n" +
                "1. Golf\n" +
                "2. Bowling\n" +
                "3. Concert\n" +
                "4. Park\n" +
                "(Pick corresponding number)");
            var outingInput = int.Parse(Console.ReadLine());
            switch (outingInput)
            {
                case 1:
                    newOuting.EventType = OutingType.Golf;
                    break;
                case 2:
                    newOuting.EventType = OutingType.Bowling;
                    break;
                case 3:
                    newOuting.EventType = OutingType.Concert;
                    break;
                case 4:
                    newOuting.EventType = OutingType.Park;
                    break;
                default:
                    break;
            }
            Console.WriteLine("How many people will be attending the event?");
            newOuting.Attendance = int.Parse(Console.ReadLine());
            Console.WriteLine("What date are you wanting the event to be on? (MM/DD/YYYY)");
            newOuting.Date = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("What would the event cost per person?(no $ sign needed)");
            newOuting.CostPerPerson = decimal.Parse(Console.ReadLine());
            Console.WriteLine("What is the total cost for the event? (no $ sign needed)");
            newOuting.TotalCost = decimal.Parse(Console.ReadLine());

            _outingRepo.AddOutingToList(newOuting);

        }

        private void Calculation()
        {
            Console.WriteLine("Would you like to calculate: \n" +
                "1. Total Outing Cost \n" +
                "2. Total Cost per Event");
            int input = int.Parse(Console.ReadLine());
            switch (input)
            {
                case 1:
                    Console.WriteLine($"Total Outing Cost: {_outingRepo.AddTotalCostOfOutings()}");
                    break;
                case 2:
                    Console.WriteLine($"Total Cost per Event:\n" +
                        $"Bowling: ${_outingRepo.AddTotalCostBowling()}\n" +
                        $"Golf: ${_outingRepo.AddTotalCostGolf()}\n" +
                        $"Concert: ${_outingRepo.AddTotalCostConcert()}\n" +
                        $"Park: ${_outingRepo.AddTotalCostPark()}\n");
                    break;
                default:
                    Console.WriteLine("That wasn't an option");
                    break;
            }
        }
    }
}
