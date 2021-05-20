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
        private Dictionary<int, List<string>> _badgeDoors = new Dictionary<int, List<string>>(); 

        public void Add(int badgeID, string _doors)
        {
            if (_badgeDoors.ContainsKey(badgeID))
            {
                List<string> doorList = _badgeDoors[badgeID];
                if (doorList.Contains(_doors) == false)
                {
                    doorList.Add(_doors);
                }
            }
            else
            {
                List<string> doorList = new List<string>();
                doorList.Add(_doors);
                _badgeDoors.Add(badgeID, doorList);
            }
        }
        //Create
        public bool CreateNewBadge(Badge newBadge)
        {
            int startingCount = _badgeDoors.Count;
            _badgeDoors.Add(newBadge.BadgeID, newBadge.Doors);
            bool wasAdded = (_badgeDoors.Count > startingCount) ? true : false;
            return wasAdded;
        }
        //Read
        public Dictionary<int, List<string>> GetBadges()
        {
            return _badgeDoors;
        }
        //Read by value

        //public List<string> GetBadgeByBadgeID(int badgeID)
        //{
        //    foreach (KeyValuePair<int, List<string>> doors in _badgeDoors)
        //    {
        //        if (doors.Key == badgeID)
        //        {
        //            return doors.Value;
        //        }
        //    }
        //    return null;
        //}
        public Badge GetBadgeByBadgeID(int badgeID)
        {
            Badge tempBadge = new Badge();
            foreach (KeyValuePair<int, List<string>> doors in _badgeDoors)
            {
                if (doors.Key == badgeID)
                {
                    tempBadge.BadgeID = doors.Key;
                    tempBadge.Doors = doors.Value;
                    return tempBadge;
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
                _badgeDoors.Remove(Convert.ToInt32(accessToDelete));
                return true;
            }
        }
    }
}
