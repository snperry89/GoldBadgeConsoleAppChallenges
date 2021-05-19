using _03_Badge_Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace _03_Badge_Console
{
    class BadgeUI
    {
        private BadgeRepo _repo = new BadgeRepo();

        public void Run()
        {
            SeedMenu();
            Menu();
        }
        public void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("Hello Security Admin.  What would you like to do?\n\n" +
                    "1. Add a badge\n" +
                    "2. Edit a badge\n" +
                    "3. List all badges\n" +
                    "4. Exit");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        AddNewBadge();
                        break;
                    case "2":
                        EditBadge();
                        break;
                    case "3":
                        ViewBadges();
                        break;
                    case "4":
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid input");
                        break;
                }
                Console.WriteLine("Please press any key to continue:");
                Console.ReadKey();
                Console.Clear();
            }
        }
        private void AddNewBadge()   //////Lost
        {
            Console.Clear();
            Badge badge = new Badge();
            //List<string> doors = new List<string>();  //unnecessary

            Console.WriteLine("Please enter the Badge ID: ");
            badge.BadgeID = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("What door does it need access to?");
            badge.Doors.Add(Console.ReadLine());
            //{
            //    return Console.ReadLine().Split(',').Select(badge.Doors).Sum();
            //}

            Console.WriteLine("Do you need access to any other doors(y/n)?");
            if (Console.ReadLine().ToLower() == "y")
            {
                Console.WriteLine("What door does it need access to?");
                badge.Doors.Add(Console.ReadLine());
            }
            else if (Console.ReadLine().ToLower() == "n")
            {
                Console.WriteLine("Press any key to continue");
            }

            _repo.CreateNewBadge(badge);
        }
        private void EditBadge()  ///// Lost
        {
            //Console.Clear();
            //Dictionary<int, List<string>> badgeDoors = _repo.GetBadges();
            //Console.WriteLine("What is the badge number you would like to update?");
            //int oldBadgeNum = Convert.ToInt32(Console.ReadLine());
            //    Badge newBadgeNum = _repo.GetBadgeByBadgeID(oldBadgeNum);
            //bool wasUpdated = _repo.UpdateDoors(oldBadgeNum, newBadgeNum);
            //if (newBadgeNum != null)
            //{
            //    Console.WriteLine($"{oldBadgeNum} has access to doors "  /*{ badgeDoors.Values}*/ );
            //    foreach (string door in badgeDoors.Values)
            //        if (newBadgeNum = Convert.ToInt32(oldBadgeNum))
            //        {
            //            Console.WriteLine(door);
            //        }

            Console.Clear();
            Dictionary<int, List<string>> badgeDoors = _repo.GetBadges();
            Console.WriteLine("What is the badge number you would like to update?");


        }
        private void ViewBadges()
        {
            Console.Clear();
            Dictionary<int, List<string>> badgeDoors = _repo.GetBadges();
            foreach (KeyValuePair<int, List<string>> badge in badgeDoors)
            {
                Console.WriteLine($"Badge ID: {badge.Key}\n" +
                $"Door Access: ");
                foreach (string door in badge.Value)
                {
                    Console.Write(door + " ");
                }
                Console.WriteLine("\n");
            }
        }
        public void SeedMenu()
        {
            Badge firstBadge = new Badge(12345, new List<string> { "A7" });
            Badge secondBadge = new Badge(22345, new List<string> { "A1", "A4", "B1", "B2" });
            Badge thirdBadge = new Badge(32345, new List<string> { "A4", "A5" });

            _repo.CreateNewBadge(firstBadge);
            _repo.CreateNewBadge(secondBadge);
            _repo.CreateNewBadge(thirdBadge);

        }
    }
}
