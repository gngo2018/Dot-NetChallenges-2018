using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_6
{
    class ProgramUI
    {
        GreenPlanRepository _greenPlanRepo = new GreenPlanRepository();

        public void RunMenu()
        {
            bool isRunning = true;
            while (isRunning)
            {
                Console.Clear();
                Console.WriteLine("Please Choose an Action\n" +
                    "1. Display List of Cars\n" +
                    "2. Add Car to List\n" +
                    "3. Update Car List\n" +
                    "4. Delete Car from List\n");
                int input = int.Parse(Console.ReadLine());
                switch (input)
                {
                    case 1:
                        DisplayCarList();
                        Console.WriteLine("Press any key to continue!");
                        Console.ReadKey();
                        break;
                    case 2:
                        AddCarToList();
                        break;
                    case 3:
                        UpdateCarList();
                        Console.WriteLine("Press any key to continue!");
                        Console.ReadKey();
                        break;
                    case 4:
                        DeleteCarFromList();
                        break;
                    default:
                        Console.WriteLine("Uhh try again");
                        Console.ReadLine();
                        break;
                }
            }
        }

        private void AddCarToList()
        {
            GreenPlan newCar = new GreenPlan();
            Console.WriteLine("What kind of car are you wanting to add: \n" +
                "1. Gas\n" +
                "2. Hybrid\n" +
                "3. Electric\n" +
                "(Pick corresponding number)");
            var carInput = int.Parse(Console.ReadLine());
            switch (carInput)
            {
                case 1:
                    newCar.TypeOfCar = CarType.Gas;
                    break;
                case 2:
                    newCar.TypeOfCar = CarType.Hybrid;
                    break;
                case 3:
                    newCar.TypeOfCar = CarType.Electric;
                    break;
                default:
                    break;
            }
            Console.WriteLine("What brand is the car?");
            newCar.CarBrand = Console.ReadLine();
            Console.WriteLine("What is the car model/style?");
            newCar.CarModel = Console.ReadLine();
            Console.WriteLine("What is the average mileage for the car?(Please use numbers)");
            newCar.AverageMileage = int.Parse(Console.ReadLine());

            if (newCar.TypeOfCar == CarType.Gas)
            {
                _greenPlanRepo.AddCarToGasList(newCar);
            }

            else if(newCar.TypeOfCar == CarType.Hybrid)
            {
                _greenPlanRepo.AddCarToHybridList(newCar);
            }

            else
            {
                _greenPlanRepo.AddCarToElectricList(newCar);
            }

        }  

        private void DisplayCarList()
        {
            Console.WriteLine("Which list of cars would you like to access?:\n" +
                "1. Gas\n" +
                "2. Hybrid\n" +
                "3. Electric cars\n");
            var input = int.Parse(Console.ReadLine());
            switch (input)
            {
                case 1:
                    int g = 0;
                    Console.WriteLine("Here is the list of Gas Cars: ");
                    foreach (GreenPlan car in _greenPlanRepo.GetGasCarList())
                    {
                        g++;
                        Console.WriteLine( g + "." +
                            $"\tType of Car: {car.TypeOfCar}\n" +
                            $"\tCar Brand: {car.CarBrand}\n" +
                            $"\tCar Model: {car.CarModel}\n" +
                            $"\tAverage Highway Mileage: {car.AverageMileage}");
                    }
                    break;
                case 2:
                    int h = 0;
                    Console.WriteLine("Here is the list of Hybrid Cars: ");
                    foreach (GreenPlan car in _greenPlanRepo.GetHybridCarList())
                    {
                        h++;
                        Console.WriteLine( h + "." +
                            $"\tType of Car: {car.TypeOfCar}\n" +
                            $"\tCar Brand: {car.CarBrand}\n" +
                            $"\tCar Model: {car.CarModel}\n" +
                            $"\tAverage Highway Mileage: {car.AverageMileage}");
                    }
                    break;
                case 3:
                    int e = 0;
                    Console.WriteLine("Here is the list of Electric Cars: ");
                    foreach (GreenPlan car in _greenPlanRepo.GetElectricCarList())
                    {
                        e++;
                        Console.WriteLine( e + "." +
                            $"\tType of Car: {car.TypeOfCar}\n" +
                            $"\tCar Brand: {car.CarBrand}\n" +
                            $"\tCar Model: {car.CarModel}\n" +
                            $"\tAverage Highway Mileage: {car.AverageMileage}");
                    }
                    break;
                default:
                    Console.WriteLine("Please try again");
                    break;
            }
        }

        private void UpdateCarList()
        {
            DisplayCarList();
            Console.WriteLine("Which car would you like to access? (Please choose corresponding number)");
            int input = int.Parse(Console.ReadLine());
            var updateCar = _greenPlanRepo.GetMasterList()[input - 1];
            Console.WriteLine("What would you like to update?\n" +
                "1. Car Brand\n" +
                "2. Car Model\n" +
                "3. Average Mileage");
            int newInput = int.Parse(Console.ReadLine());
            switch (newInput)
            {
                case 1:
                    Console.WriteLine("What brand is the car?");
                    updateCar.CarBrand = Console.ReadLine();
                    break;
                case 2:
                    Console.WriteLine("What model is the car?");
                    updateCar.CarModel = Console.ReadLine();
                    break;
                case 3:
                    Console.WriteLine("What is the average mileage the car gets?");
                    updateCar.AverageMileage = int.Parse(Console.ReadLine());
                    break;
                default:
                    break;
            }
        }

        private void DeleteCarFromList()
        {
            DisplayCarList();
            Console.WriteLine("Which car would you like to access? (Please choose corresponding number)");
            int deleteCar = int.Parse(Console.ReadLine());
            if (deleteCar == 1)
            {
                _greenPlanRepo.GetGasCarList().RemoveAt(deleteCar - 1);
            }
            else if (deleteCar == 2)
            {
                _greenPlanRepo.GetHybridCarList().RemoveAt(deleteCar - 1);
            }
            else
            {
                _greenPlanRepo.GetElectricCarList().RemoveAt(deleteCar - 1);
            }
        }

        private void MasterList()
        {
            int i = 0;
            Console.WriteLine("Here is the master list of all cars: ");
            foreach (GreenPlan master in _greenPlanRepo.GetMasterList())
            {
                i++;
                Console.WriteLine(i + "." +
                    $"\tType of Car: {master.TypeOfCar}\n" +
                    $"\tCar Brand: {master.CarBrand}\n" +
                    $"\tCar Model: {master.CarModel}\n" +
                    $"\tAverage Highway Mileage: {master.AverageMileage}");
            }
        }
    }
}
