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
        /// tried to employ following helper method
        //public void DisplayAccess()
        //{
        //    Dictionary<int, List<string>> badgeDoors = _repo.GetBadges();
        //    int badgeNum = Convert.ToInt32(Console.ReadLine());
        //    Badge newBadgeNum = _repo.GetBadgeByBadgeID(badgeNum);
        //    Console.WriteLine($"\nBadge {badgeNum} has access to doors: ");
        //    foreach (KeyValuePair<int, List<string>> badge in badgeDoors)
        //    {
        //        //foreach (string doors in badge.Value)
        //        foreach (string doors in badgeDoors[badgeNum])
        //        {
        //            if (badgeNum == badge.Key)
        //            {
        //                Console.WriteLine($"{ doors} \n");
        //            }
        //            else
        //            {
        //                //Console.WriteLine("Badge not recognized");
        //            }
        //        }
        //    }
        //}
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
        private void AddNewBadge()
        {
            Console.Clear();
            Badge badge = new Badge();

            Console.WriteLine("Please enter the Badge ID: ");
            badge.BadgeID = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("What door does it need access to?");
            string doors = Console.ReadLine();
            badge.Doors = doors.Split(' ').ToList();

            bool continueLoop = true;
            while (continueLoop)
            {
                Console.WriteLine("Do you need access to any other doors(y/n)?");
                string input = Console.ReadLine().ToLower();
                if (input == "y")
                {
                    Console.WriteLine("What door does it need access to?");
                    badge.Doors.Add(Console.ReadLine());
                }
                else if (input == "n")
                {
                    continueLoop = false;
                    Console.WriteLine("No additional access was granted");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("Please enter a valid input:");
                }
            }
            _repo.CreateNewBadge(badge);
        }
        private void EditBadge() 
        {
            Console.Clear();
            Dictionary<int, List<string>> badgeDoors = _repo.GetBadges();

            Console.WriteLine("What is the badge number you would like to update?");
            int badgeNum = Convert.ToInt32(Console.ReadLine());
            Badge newBadgeNum = _repo.GetBadgeByBadgeID(badgeNum);

            //Is this below used???
            bool wasUpdated = _repo.UpdateDoors(badgeNum, newBadgeNum);

            if (newBadgeNum != null)
            {
                Console.WriteLine($"\nBadge {badgeNum} has access to doors: ");
                foreach (KeyValuePair<int, List<string>> badge in badgeDoors)
                {
                    foreach (string doors in badgeDoors[badgeNum])
                    {
                        if (badgeNum == badge.Key)
                        {
                            Console.WriteLine($"{ doors} \n");
                        }
                        else
                        {
                            //Console.WriteLine("Badge not recognized");
                        }
                    }
                }
                Console.WriteLine("What would you like to do?\n" +
                        "1. Remove a door\n" +
                        "2. Add a door");
                string input = Console.ReadLine();
                if (input == "1")
                {
                    Console.WriteLine("\nWhich door would you like to remove");

                    string deleteDoor = Console.ReadLine();
                    _repo.Remove(badgeNum, deleteDoor);

                    Console.WriteLine($"\nBadge {badgeNum} no longer has access to door: {deleteDoor}\n");
                    Console.WriteLine($"\nBadge {badgeNum} has access to doors: ");
                    foreach (KeyValuePair<int, List<string>> badge in badgeDoors)
                    {

                        foreach (string doors in badgeDoors[badgeNum])
                        {
                            if (badgeNum == badge.Key)
                            {
                                Console.WriteLine($"{ doors} \n");
                            }
                            else
                            {
                                //Console.WriteLine("Badge not recognized");
                            }
                        }
                    }
                   
                }
                if (input == "2")
                {
                    Console.WriteLine("\nWhich door would you like to add");
                    string addDoor = Console.ReadLine();
                    _repo.Add(badgeNum, addDoor);

                    // need to make below output show all doors that badge has access to
                    Console.WriteLine($"\nBadge {badgeNum} now has access to door: {addDoor}\n");
                    //DisplayAccess();  -- How to implement this helper method instead of copying multiple times
                    Console.WriteLine($"\nBadge {badgeNum} has access to doors: ");
                    foreach (KeyValuePair<int, List<string>> badge in badgeDoors)
                    {
                        foreach (string doors in badgeDoors[badgeNum])
                        {
                            if (badgeNum == badge.Key)
                            {
                                Console.WriteLine($"{ doors} \n");
                            }
                            else
                            {
                                //Console.WriteLine("Badge not recognized");
                            }
                        }
                    }
                }
            }
        }
        private void ViewBadges()
        {
            Console.Clear();
            Dictionary<int, List<string>> badgeDoors = _repo.GetBadges();
            foreach (KeyValuePair<int, List<string>> badge in badgeDoors)
            {
                Console.WriteLine($"Badge ID: {badge.Key}\n" +
                $"Door Access: ");
                foreach (string doors in badge.Value)
                {
                    Console.Write(doors + " ");
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

