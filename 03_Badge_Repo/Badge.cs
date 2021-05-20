using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Badge_Repo
{
    public class Badge
    {
        public int BadgeID { get; set; }
        public List<string> Doors { get; set; }
        public Badge() { }
        public Badge(int badgeID, List<string> _doors)
        {
            BadgeID = badgeID;
            Doors = _doors;
        }
    }
}
