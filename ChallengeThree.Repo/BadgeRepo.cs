using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeThree.Repo
{
    class BadgeRepo
    {
        private readonly Dictionary<int, BadgeContent> _badgeDict = new Dictionary<int, BadgeContent>();

        //create
        public void AddBadgetoDict(BadgeContent badge)
        {

        }
        //read
        public Dictionary<int,BadgeContent> GetBadgeList()
        {
            return _badgeDict;
        }
        //update
        public bool UpdateBadge(int badgeKey, BadgeContent newID)
        {
            BadgeContent oldID = GetBadgeByKey(badgeKey);

            if (oldID != null)
            {
                oldID.BadgeID = newID.BadgeID;
                oldID.DoorNames = newID.DoorNames;

                return true;
            }
            else
            {
                return false;
            }
        }
        //delete
        public bool RemoveBadge(int badgeKey)
        {
            BadgeContent badge = GetBadgeByKey(badgeKey);
            {
                if (badge == null)
                {
                    return false;
                }

                int intitialCount = _badgeDict.Count;

                _badgeDict.Remove(badge.BadgeID);

                if(intitialCount > _badgeDict.Count)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
        }


        //helper
        public BadgeContent GetBadgeByKey(int badgeKey)
        {
            foreach (var pair in _badgeDict)
            {
                if (pair.Key == badgeKey)
                {
                    return pair.Value;
                }
            }

            return null;
        }
    }
}
