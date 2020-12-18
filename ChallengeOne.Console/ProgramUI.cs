using System;
using System.Collections.Generic;
using System.Linq;
using ChallengeOne.Repo;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeOne.Console
{
    public class ProgramUI
    {//runs and starts method

        private readonly MenuContentRepo _menuContentRepo = new MenuContentRepo();


        public void Run()
        {
            SeedMenuList();
            Menu();
        }

        private void Menu()
        {

            bool keepRunning = true;
            while (keepRunning)
            {//display
                System.Console.WriteLine("Welcome to Komodo Cafe!\n" +
                    "1. Add Menu Item\n" +
                    "2. View Menu\n" +
                    "3. View Item by Number\n" +
                    "4. Update Menu Item\n" +
                    "5. Delete Menu Item\n"+
                    "6. Close Application");

                //input from user
                string input = System.Console.ReadLine();
                //act from input
                switch (input)
                {
                    case "1":
                        AddNewItem();
                        break;
                    case "2":
                        DisplayMenu();
                        break;
                    case "3":
                        ViewByNumber();
                        break;
                    case "4":
                        UpdateMenuItem();
                        break;
                    case "5":
                        DeleteMenuItem();
                        break;
                    case "6":
                        System.Console.WriteLine("Goodbye!");
                        keepRunning = false;
                        break;
                    default:
                        System.Console.WriteLine("Please enter a valid number...");
                        break;
                }
                System.Console.WriteLine("Please press any key to continue...");
                System.Console.ReadKey();
                System.Console.Clear();
            }

        }
        private void AddNewItem()
        {
            System.Console.Clear();
            MenuContent newContent = new MenuContent();

            System.Console.WriteLine("Item Name");
            newContent.MealName = System.Console.ReadLine();

            System.Console.WriteLine("Number");
            newContent.MealNumber = Convert.ToInt32(System.Console.ReadLine());

            System.Console.WriteLine("Description");
            newContent.Description = System.Console.ReadLine();

            System.Console.WriteLine("Ingredients");
            newContent.Ingredients = System.Console.ReadLine();

            System.Console.WriteLine("Price");
            newContent.Price = Convert.ToInt32(System.Console.ReadLine());

        }
        private void DisplayMenu()
        {
            System.Console.Clear();

            List<MenuContent> menuContents = _menuContentRepo.GetMenuContentList();

            foreach( MenuContent content in menuContents)
            {
                System.Console.WriteLine($"Name: {content.MealName},\n" +
                    $"Number: {content.MealNumber},\n" +
                    $"Description: {content.Description},\n" +
                    $"Ingredients: {content.Ingredients},\n" +
                    $"Price: {content.Price}");
            }

        }
        private void ViewByNumber()
        {
            System.Console.Clear();
            System.Console.WriteLine("Enter Item Number");

            int ID = Convert.ToInt32(System.Console.ReadLine());

            MenuContent content = _menuContentRepo.GetContentByID(ID);

            if(content != null)
            {
                System.Console.WriteLine($"Name: {content.MealName},\n" +
                   $"Number: {content.MealNumber},\n" +
                   $"Description: {content.Description},\n" +
                   $"Ingredients: {content.Ingredients},\n" +
                   $"Price: {content.Price}");
            }
            else
            {
                System.Console.WriteLine("No Item with that number");
            }


        }
        private void UpdateMenuItem()
        {
            System.Console.Clear();

            DisplayMenu();

            System.Console.WriteLine("\nEnter the Item Number of the Item you would like to Update.");
            //get item from number
            string oldContent =System.Console.ReadLine();
            //########################################################################int?#######
            System.Console.Clear();

            MenuContent newContent = new MenuContent();

            System.Console.WriteLine("Item Name");
            newContent.MealName = System.Console.ReadLine();

            System.Console.WriteLine("Number");
            newContent.MealNumber = Convert.ToInt32(System.Console.ReadLine());

            System.Console.WriteLine("Description");
            newContent.Description = System.Console.ReadLine();

            System.Console.WriteLine("Ingredients");
            newContent.Ingredients = System.Console.ReadLine();

            System.Console.WriteLine("Price");
            newContent.Price = Convert.ToInt32(System.Console.ReadLine());

            //Verify
            bool wasUpdated = _menuContentRepo.UpdateExistingContent(oldContent, newContent);
            if (wasUpdated)
            {
                System.Console.WriteLine("Updated!");
            }
            else
            {
                System.Console.WriteLine("Unable to Update :( ");
            }


        }
        private void DeleteMenuItem()
        {
            DisplayMenu();
            System.Console.WriteLine("\nEnter the Number of the Item you would like to delete:");

            string input = System.Console.ReadLine();
            //call delete method 
            bool wasDeleted = _menuContentRepo.RemoveContentFromList(input);
            if (wasDeleted)
            {
                System.Console.WriteLine("Deleted!");
            }
            else
            {
                System.Console.WriteLine("Unable to Delete :( ");
            }



        }
        public void SeedMenuList()
        {
            MenuContent burger = new MenuContent(1,"Vegan Burger", "Chickpea Patty made with rice, onions, and chickpease", "Chickpea, rice, onion", 5 );
            MenuContent salad = new MenuContent(2, "Fresh Salad", "salad made from locally sourced gardens", "Spinach, Chickweed, Mustard Weed", 6);
            MenuContent zoodle = new MenuContent(3, "Zoodle Bowl", "Zucchini Noodle bowl", "Zucchini, Chickpeas, Avacodo Sauce", 6);
            MenuContent mac = new MenuContent(4, "Vegan Mac and Cheese", "Mac and Cheese without the Mac or Cheese",  "House made chickpea noodle, Vegan Cheese sauce", 6);

            _menuContentRepo.AddContentToList(burger);
            _menuContentRepo.AddContentToList(salad);
            _menuContentRepo.AddContentToList(zoodle);
            _menuContentRepo.AddContentToList(mac);
        }
    }
}
