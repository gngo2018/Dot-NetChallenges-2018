using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_2
{
    public class ProgramUI
    {
        ClaimRepository _claimRepo = new ClaimRepository();

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
                Console.WriteLine("Please choose an action: \n" +
                    "1. Enter Claim\n" +
                    "2. See All Claims\n" +
                    "3. View Claim Queue\n" +
                    "4. Exit");
                int input = int.Parse(Console.ReadLine());
                switch (input)
                {
                    case 1:
                        SubmitClaim();
                        break;
                    case 2:
                        SeeAllClaim();
                        Console.WriteLine("Press any key to continue!");
                        Console.ReadKey();
                        break;
                    case 3:
                        ClaimQueue();
                        Console.ReadKey();
                        break;
                    case 4:
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("Try again please");
                        Console.ReadKey();
                        break;
                }
            }
            Console.WriteLine("Have a great day!");
        }

        private void SubmitClaim()
        {
            Claim newClaimItem = new Claim();
            Console.WriteLine("What ID number would you like to associate the claim with?");
            newClaimItem.ClaimID = int.Parse(Console.ReadLine());
            Console.WriteLine("What type of claim is it? (Car, Home, or Theft)");
            newClaimItem.ClaimType = Console.ReadLine();
            Console.WriteLine("What is the claim amount? (Enter amount w/o $ sign)");
            newClaimItem.ClaimAmount = decimal.Parse(Console.ReadLine());
            Console.WriteLine("What is the description of the claim?");
            newClaimItem.Description = Console.ReadLine();
            Console.WriteLine("What was the date of the incident?");
            newClaimItem.DateOfIncident = Console.ReadLine();
            Console.WriteLine("Processing date of claim");
            newClaimItem.DateOfClaim = Console.ReadLine();
            Console.WriteLine("Is incident date within 30 days of processing?(y/n)");
            string answer = Console.ReadLine();
            if (answer.Contains("y"))
            {
                newClaimItem.IsValid = true;
            }
            else
            {
                newClaimItem.IsValid = false;
            }

            _claimRepo.AddClaimToQueue(newClaimItem);

        }

        private void SeeAllClaim()
        {
            Console.WriteLine("The current list of processed claims are:");

            foreach (Claim claimItem in _claimRepo.GetClaimList())
            {
                Console.WriteLine(
                    $"\tClaim ID: {claimItem.ClaimID}\n\t" +
                    $"Claim Type: {claimItem.ClaimType}\n\t" +
                    $"Claim Amount: ${claimItem.ClaimAmount}\n\t" +
                    $"Claim Description: {claimItem.Description}\n\t" +
                    $"Date of Incident: {claimItem.DateOfIncident}\n\t" +
                    $"Date of Processing: {claimItem.DateOfClaim}\n\t" +
                    $"Within 30 Days: {claimItem.IsValid}\n\t");
            }
        }

        private void ClaimQueue()
        {
            Console.WriteLine("The current claim on queue is:");
            Console.WriteLine(
                    $"\tClaim ID: {_claimRepo.GetClaimList().Peek().ClaimID}\n\t" +
                    $"Claim Type: {_claimRepo.GetClaimList().Peek().ClaimType}\n\t" +
                    $"Claim Amount: ${_claimRepo.GetClaimList().Peek().ClaimAmount}\n\t" +
                    $"Claim Description: {_claimRepo.GetClaimList().Peek().Description}\n\t" +
                    $"Date of Incident: {_claimRepo.GetClaimList().Peek().DateOfIncident}\n\t" +
                    $"Date of Processing: {_claimRepo.GetClaimList().Peek().DateOfClaim}\n\t" +
                    $"Within 30 Days: {_claimRepo.GetClaimList().Peek().IsValid}\n\t");
            Console.WriteLine("Would you like to resolve the current claim?(y/n)");
            string response = Console.ReadLine();
            if (response.Contains("y"))
            {
                _claimRepo.GetClaimList().Dequeue();
                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
            }
        }

    }
}
