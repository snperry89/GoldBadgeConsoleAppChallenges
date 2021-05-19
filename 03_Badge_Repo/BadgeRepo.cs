using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Badge_Repo
{
    public class BadgeRepo
    {
        ///stackoverflow.com/questions/17887407/dictionary-with-list-of-strings-as-value
        private Dictionary<int, List<string>> badgeDoors = new Dictionary<int, List<string>>();
        public void Add(int badgeID, string _doors)
        {
            if (this.badgeDoors.ContainsKey(badgeID))
            {
                List<string> doorList = this.badgeDoors[badgeID];
                if (doorList.Contains(_doors) == false)
                {
                    doorList.Add(_doors);
                }
            }
            else
            {
                List<string> doorList = new List<string>();
                doorList.Add(_doors);
                this.badgeDoors.Add(badgeID, doorList);
            }
        }
        //Create
        public bool CreateNewBadge(Badge newBadgeID, List<string> _doors)
        {
            int startingCount = badgeDoors.Count;
            badgeDoors.Add(Convert.ToInt32(newBadgeID), _doors);
            bool wasAdded = (badgeDoors.Count > startingCount) ? true : false;
            return wasAdded;
        }
        //Read
        public Dictionary<int, List<string>> GetBadges()
        {
            return badgeDoors;
        }
        //Read by value
        public Badge GetBadgeByBadgeID(int badgeID)
        {
            foreach (Badge newbadgeID in badgeDoors)
            {
                if (newbadgeID.BadgeID == badgeID)
                    {
                    return newbadgeID;
                }
            }
            return null;
        }
        //Update
        public bool UpdateDoors(int originalBadgeID, Badge newBadgeAccess)
        {
            Badge oldBadgeID = GetBadgeByBadgeID(originalBadgeID);
            if (oldBadgeID != null)
            {
                oldBadgeID.BadgeID = newBadgeAccess.BadgeID;
                return true;
            }
            else
            {
                return false;
            }
        }
        //Delete
        public bool DeleteDoors(int doorAccessToDelete)
        {
            Badge accessToDelete = GetBadgeByBadgeID(doorAccessToDelete);
            if (accessToDelete == null) {
                return false;
            }
            else
            {
                badgeDoors.Remove(Convert.ToInt32(accessToDelete));
                return true;
            }
        }
    }
}
