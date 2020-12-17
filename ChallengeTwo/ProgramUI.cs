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
                    "4. Delete Claim\n" +
                    "5. Exit");

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
                        DeleteClaim();
                        break;
                    case "5":
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

            Queue<ClaimContent> claimPeek = _claimRepo.GetClaimQueue();
            Console.WriteLine($"{ "ID",-25} {"Type",-25}{"Description",-25}{"Amount",-12}{"Date Of Claim",-27}{"IsValid",-25} ");
            foreach (ClaimContent content in claimPeek)
            {
                Console.WriteLine($" {content.ClaimID,-25} {content.TypeOfClaim,-25}{content.Description,-25}{"$" + content.ClaimAmount,-12}{content.DateOfIncident,-27}{content.IsValid,-23}");

            }


            }

           private void DisplayClaims(ClaimContent content)
            {
            Console.WriteLine($"{ "ID",-25} {"Type",-25}{"Description",-25}{"Amount",-12}{"Date Of Claim",-27}{"IsValid",-25} ");
            Console.WriteLine($" {content.ClaimID,-25} {content.TypeOfClaim,-25}{content.Description,-25}{"$" + content.ClaimAmount,-12}{content.DateOfIncident,-27}{content.IsValid,-23}");
             }


            private void NextClaim()
            {
            Console.Clear();

            ClaimContent contents = _claimRepo.GetNextClaim();
            if (contents != null)
            {

                DisplayClaims(contents);
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
       

        private void DeleteClaim()
        {
           
            NextClaim();
            Console.WriteLine("Do you want to delete this Claim? y/n");

            string input = Console.ReadLine().ToLower();
            switch (input)
            {
                case "y":
                    _claimRepo.RemoveClaim();
                    Console.WriteLine("Claim deleted");
                    break;
                        case "n":
                    Console.WriteLine("Claim not deleted");
                    break;

            }
           
            

        }
        public void SeedQueue()
        {
            ClaimContent car = new ClaimContent(1, ClaimType.Car, "Car accident on 464.", 400, new DateTime(2018/4/25), true );
            ClaimContent home = new ClaimContent(2, ClaimType.Home, "House Fire in Kitchen", 4000, new DateTime(2018 / 4 / 11), false);
            ClaimContent theft = new ClaimContent(3, ClaimType.Theft, "Stolen Pancakes", 4, new DateTime(2018 / 4 / 27), true);


            _claimRepo.AddClaimToQueue(car);
            _claimRepo.AddClaimToQueue(home);
            _claimRepo.AddClaimToQueue(theft);
        }
    }
}
