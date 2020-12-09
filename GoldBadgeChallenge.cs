using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeOne.Repo
{
    public class MenuContentRepo
    {
        private List<MenuContent> _listOfMenuContent = new List<MenuContent>();

        //create
        public void AddContentToList(MenuContent content)
        {
            _listOfMenuContent.Add(content);
        }

        //read
        public List<MenuContent> GetMenuContentList()
        {
            return _listOfMenuContent; 
        }

        //update
        public bool UpdateExistingContent(string originalName, MenuContent newContent)
        {
            //Find Content
            MenuContent oldContent = GetContentByName(originalName);
            //Update content
            if(oldContent != null)
            {
                oldContent.MealName = newContent.MealName;
                oldContent.Ingredients = newContent.Ingredients;
                oldContent.MealNumber = newContent.MealNumber;
                oldContent.Description = newContent.Description;
                oldContent.Price = newContent.Price;
                return true;
            }
            else
            {
                return false;
            }
        }

        //delete
        public bool RemoveContentFromList(string name)
        {
            MenuContent content = GetContentByName(name);

            if (content == null)
            {
                return false;
            }

            int initialCount = _listOfMenuContent.Count;
            _listOfMenuContent.Remove(content);

            if (initialCount > _listOfMenuContent.Count)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        //Helper-
        public MenuContent GetContentByName(string name)
        {
            foreach(MenuContent content in _listOfMenuContent)
            {
                if(content.MealName == name)
                {
                    return content;
                }
            }
            return null;
        }
    }
}
