using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeOne.Repo
{

    //public enum MealType { 1}

    //POCO-simple class that is an object, holds data
    public class MenuContent
    {

        public int MealNumber { get; set; }
        public string MealName { get; set; }
        public string Description { get; set; }
        public string Ingredients { get; set; }
        public int Price { get; set; }

        //public MealType TypeOfMeal { get; set; }

        public MenuContent() { }
        public MenuContent(int mealnumber, string mealname, string description, string ingredients, int price)
        {
            MealNumber = mealnumber;
            MealName = mealname;
            Description = description;
            Ingredients = ingredients;
            Price = price;
        }
    }
}
