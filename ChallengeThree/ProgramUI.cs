using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChallengeThree.Repo;

namespace ChallengeThree
{
    public class ProgramUI
    {
        private readonly BadgeRepo _badgeRepo = new BadgeRepo();
            public void Run()
        {
            SeedBadgeList();
            UIMenu();
        }

        private void UIMenu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("What would you like to do?:\n" +
                    "1. Add a Badge\n" +
                    "2. List all Badges\n" +
                    "3. View Badges Permissions by ID\n" +
                    "4. Edit an Existing Badge\n" +
                    "5. Delete An Existing Badge\n" +
                    "6. Exit" );

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        AddNewBadge();
                        break;
                    case "2":
                        DisplayAllBadges();
                        break;
                    case "3":
                        DisplayByID();
                        break;
                    case "4":
                        UpdateBadge();
                        break;
                    case "5":
                        DeleteBadge();
                        break;
                            case "6":
                        Console.WriteLine("Goodbye!");
                        keepRunning = false;
                            break;
                    default:
                        Console.WriteLine("Please enter a number");
                        break;
   
                }
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }

        private void AddNewBadge()
        {
            Console.Clear();
            List<string> stringList = new List<string>();

            Console.WriteLine("Enter a new Badge Number:");
            string badgeNumber = Console.ReadLine();
            int badgeInt = Convert.ToInt32(badgeNumber);

            bool askForDoor = true;

            while (askForDoor == true)
            {
                Console.WriteLine("What door would you like to add?");
                string newDoor = Console.ReadLine();
                stringList.Add(newDoor);
                Console.WriteLine("Add another door? y/n\n");
                string input = Console.ReadLine().ToLower();
                if (input == "y")
                {
                    askForDoor = true;
                }
                else if (input == "n")
                {
                    askForDoor = false;
                }
            }

            BadgeContent newBadge = new BadgeContent(badgeInt, stringList);
            _badgeRepo.AddBadgetoDict(newBadge);

        }
        private void DisplayAllBadges()
        {
            Console.Clear();

            Dictionary<int, BadgeContent> badgeDictionary = _badgeRepo.GetBadgeList();

            foreach (var badge in badgeDictionary)
          
                DisplayBadge(badge.Value);
               
           
        }

        //helper
        private void DisplayBadge(BadgeContent badge)
        {

            Dictionary<int, BadgeContent> badgeDictionary = _badgeRepo.GetBadgeList();
            foreach(var pair in badgeDictionary)
            {
                Console.Write($"Badge Info: {badge.BadgeID}\t\t");
                foreach (string door in pair.Value.DoorNames)
                {
                    Console.Write(door +" ");
                }
                Console.Write("\n");
            }
            

            

        }
        private void DisplayByID()
        {
            Console.Clear();

            Console.WriteLine("Enter Badge number to display:");

            int oldID = Convert.ToInt32(Console.ReadLine());

            BadgeContent badge = _badgeRepo.GetBadgeByKey(oldID);

            if (badge != null)
            {
                DisplayBadge(badge);
            }
            else
            {
                Console.WriteLine("No Recored of Badge");
            }

        }
        private void UpdateBadge()
        {
            Console.Clear();

            DisplayAllBadges();

            Console.WriteLine("Which Badge would you like to update?");

            int oldID = Convert.ToInt32(Console.ReadLine());

            List<string> stringList = new List<string>();

            bool askForDoor = true;

            while (askForDoor == true)
            {
                Console.WriteLine("What door would you like to add?");
                string newDoor = Console.ReadLine();
                stringList.Add(newDoor);
                Console.WriteLine("Add another door? y/n\n");
                string input = Console.ReadLine().ToLower();
                if (input == "y")
                {
                    askForDoor = true;
                }
                else if (input == "n")
                {
                    askForDoor = false;
                }
            }

            BadgeContent updatedBadge = new BadgeContent(oldID, stringList);

            bool updated = _badgeRepo.UpdateBadge(oldID, updatedBadge);

            if (updated)
            {
                Console.WriteLine("Badge Updated");
            }
            else
            {
                Console.WriteLine("Unable to update");
            }
        }

        private void DeleteBadge()
        {
            DisplayAllBadges();

            Console.WriteLine("Enter Badge ID to delete");
            int oldID = Convert.ToInt32(Console.ReadLine());

            bool deleted = _badgeRepo.RemoveBadge(oldID);

            if (deleted)
            {
                Console.WriteLine("Badge Deleted");
            }
            else
            {
                Console.WriteLine("Unable to Delete");
            }

        }

        private void SeedBadgeList()
        {
            List<string> list = new List<string>();
            list.Add("B4");
            list.Add("B3");



            BadgeContent badge1 = new BadgeContent(12345, new List<string> { "A7" });
            BadgeContent badge2 = new BadgeContent(12346, new List<string> { "A7,A4,B1,B3" });
            BadgeContent badge3 = new BadgeContent(12347, new List<string> { "A7,A3,B4" });
            BadgeContent badge4 = new BadgeContent(12348, new List<string> { "A7,B3,B4" });

            _badgeRepo.AddBadgetoDict(badge1);
            _badgeRepo.AddBadgetoDict(badge2);
            _badgeRepo.AddBadgetoDict(badge3);
            _badgeRepo.AddBadgetoDict(badge4);


        }


    }
}
