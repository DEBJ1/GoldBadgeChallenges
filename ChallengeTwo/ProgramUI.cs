using ChallengeTwo.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeTwo
{
    class ProgramUI
    {
        private ClaimContentRepo _claimRepo = new ClaimContentRepo();

        //start app

        public void Run()
        {
            SeedQueue();
            Menu();

        }
        //menu
        private void Menu()
        {
            bool keeprunning = true;
            while (keeprunning)
            {
                //display
                Console.WriteLine("What would you like to do?\n" +
                    "1. See all Claims\n" +
                    "2. Take Care of Next Claim\n" +
                    "3. Enter a New Claim\n" +
                    "4. Exit Application");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        DisplayAllClaims();
                        break;
                    case "2":
                        NextClaim();
                        break;
                    case "3":
                        NewClaim();
                        break;
                    case "4":
                        Console.WriteLine("Goodbye");
                        keeprunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number...");
                        break;
                }

                Console.WriteLine("Please press any key to continue...");
                Console.ReadKey();

                Console.Clear();
            }
        }


            private void DisplayAllClaims()
            {
            Console.Clear();

            Queue<ClaimContent> claimQueue = _claimRepo.GetClaimQueue();

            foreach (ClaimContent content in claimQueue)
            {
                System.Console.WriteLine($"ID: {content.ClaimID},\n" +
                  $"Type: {content.TypeOfClaim},\n" +
                  $"Description: {content.Description},\n" +
                  $"Amount: {content.ClaimAmount},\n" +
                  $"Date: {content.DateOfIncident},\n" +
                  $"IsValid: {content.IsValid}");
            }

           
            }

            private void NextClaim()
            {
            Console.Clear();

            Queue<ClaimContent> claimPeek = _claimRepo.GetNextClaim();
            Console.WriteLine($"{ "ID",-25} {"Type", -25}{"Description",-25}{"Amount",-12}{"Date Of Claim",-27}{"IsValid",-25} ");
            foreach (ClaimContent content in claimPeek)
            {
                Console.WriteLine($" {content.ClaimID, -25} {content.TypeOfClaim,-25}{content.Description,-25}{content.ClaimAmount,-12}{content.DateOfIncident,-27}{content.IsValid,-25}");


            }

        }
            private void NewClaim()
            {
            Console.Clear();
            ClaimContent newContent = new ClaimContent();

            Console.WriteLine("Enter ID");
            newContent.ClaimID = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter Type of Claim:\n" +
                "1. Car\n" +
                "2. Home\n" +
                "3. Theft");
            string typeAsString = Console.ReadLine();
            int typeAsInt = int.Parse(typeAsString);
            newContent.TypeOfClaim = (ClaimType)typeAsInt;


            Console.WriteLine("Enter Description");
            newContent.Description = Console.ReadLine();

            Console.WriteLine("Enter Amount");
            newContent.ClaimAmount = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Is this Claim valid? Y/N");
            string isValid = Console.ReadLine().ToLower();

            if (isValid == "y")
            {
                newContent.IsValid = true;
            }
            else
            {
                newContent.IsValid = false;
            }

            _claimRepo.AddClaimToQueue(newContent);
        }
       
        public void SeedQueue()
        {
            ClaimContent car = new ClaimContent(1, ClaimType.Car, "Car accident on 464.", 400, new DateTime(2018/4/25), true );

            _claimRepo.AddClaimToQueue(car);
        }
    }
}
