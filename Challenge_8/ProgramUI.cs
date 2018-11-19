using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_8
{
    class ProgramUI
    {
        SmartInsuranceRepository _smartInsuranceRepo = new SmartInsuranceRepository();

        public void RunMenu()
        {
            bool isRunning = true;
            while (isRunning)
            {
                Console.Clear();
                Console.WriteLine("Select an option:\n" +
                    "1. Add Driver Info\n" +
                    "2. Show Driver Info and Premium\n" +
                    "3. Remove Driver from List\n" +
                    "4. Update Driver Info");
                int input = int.Parse(Console.ReadLine());
                switch (input)
                {
                    case 1:
                        CreateDriver();
                        break;
                    case 2:
                        ShowInfoAndPremium();
                        Console.WriteLine("Press any key to continue!");
                        Console.ReadKey();
                        break;
                    case 3:
                        RemoveDriver();
                        break;
                    case 4:
                        UpdateDriver();
                        break;
                }
            }
        }

        private void CreateDriver()
        {
            SmartInsurance newDriver = new SmartInsurance();
         
            Console.WriteLine("What type of car does the owner have: \n" +
                "1. Sport\n" +
                "2. Small\n" +
                "3. Medium\n" +
                "4. Large\n" +
                "(Pick corresponding number)");
            var userInput = int.Parse(Console.ReadLine());
            switch (userInput)
            {
                case 1:
                    newDriver.CarType = CarStyle.Sport;
                    break;
                case 2:
                    newDriver.CarType = CarStyle.Small;
                    break;
                case 3:
                    newDriver.CarType = CarStyle.Medium;
                    break;
                case 4:
                    newDriver.CarType = CarStyle.Large;
                    break;
            }
            Console.WriteLine("What is the driver's name?");
            newDriver.DriverName = Console.ReadLine();
            Console.WriteLine("What is the driver's average speed per trip?(In numbers, no mph needed at end)");
            newDriver.AverageSpeed = int.Parse(Console.ReadLine());
            Console.WriteLine("Does the driver tailgate other cars often?(y/n)");
            var answer = Console.ReadLine();
            if (answer.Contains("y"))
            {
                newDriver.DoesTailgate = true;
            }
            else
            {
                newDriver.DoesTailgate = false;
            }
            Console.WriteLine("Does the driver roll past the stop sign?(y/n)");
            answer = Console.ReadLine();
            if (answer.Contains("y"))
            {
                newDriver.StopOrRoll = true;
            }
            else
            {
                newDriver.StopOrRoll = false;
            }

            Console.WriteLine("Does the driver swerve out of their lane often?(y/n)");
            answer = Console.ReadLine();
            if (answer.Contains("y"))
            {
                newDriver.Swerve = true;
            }
            else
            {
                newDriver.Swerve = false;
            }

            _smartInsuranceRepo.AddInfoToList(newDriver);
        }

        private void DriverInformation()
        {
            int i = 0;
            foreach (SmartInsurance driver in _smartInsuranceRepo.GetInfoList())
            {
                i++;
                Console.WriteLine(i + "." +
                    $"\tDriver Name: {driver.DriverName}\n" +
                    $"\tCar Type: {driver.CarType}\n" +
                    $"\tAverage Speed: {driver.AverageSpeed} mph\n" +
                    $"\tTailgates Often: {driver.DoesTailgate}\n" +
                    $"\tRolls Stop Signs: {driver.StopOrRoll} \n" +
                    $"\tSwerves Often: {driver.Swerve}\n");
            }
        }

        private void ShowInfoAndPremium()
        {
            Console.WriteLine("Would you like to view: \n" +
                "1. Driver Info\n" +
                "2. Premium Info");
            int input = int.Parse(Console.ReadLine());
            switch (input)
            {
                case 1:
                    DriverInformation();
                    break;

                case 2:
                    _smartInsuranceRepo.CalculatedPremium();
                    foreach (SmartInsurance driver in _smartInsuranceRepo.GetInfoList())
                    {
                        Console.WriteLine($"The breakdown of charges for {driver.DriverName} include: \n" +
                            $"Base: $100\n" +
                            $"Car Type Cost: ${driver.PremiumCost}\n" +
                            $"Speeding: ${driver.SpeedingCost}\n" +
                            $"Tailgating: ${driver.TailgateCost}\n" +
                            $"Rolling Stop Signs: ${driver.StopCost}\n" +
                            $"Swerving Often: ${driver.SwerveCost}\n");
                    }
                    break;
                default:
                    Console.WriteLine("Please try again!");
                    break;
            }
        }

        private void RemoveDriver()
        {
            DriverInformation();
            Console.WriteLine("Which driver would you like to remove?");
            int input = int.Parse(Console.ReadLine());
            _smartInsuranceRepo.GetInfoList().RemoveAt(input - 1);
        }

        private void UpdateDriver()
        {
            DriverInformation();
            Console.WriteLine("Which driver would you like to update? (Pick corresponding number)");
            int input = int.Parse(Console.ReadLine());
            _smartInsuranceRepo.GetInfoList().RemoveAt(input - 1);
            CreateDriver();
        }

        //When showing cost, was not able to get total $ amount per type. Had same trouble in challenge 3 with event type w/o using multiple loops
    }
}
