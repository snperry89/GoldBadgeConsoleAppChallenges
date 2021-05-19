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
    }
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
            Console.WriteLine("Hello Security Admin.  What would you like to do?\n" +
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
                    ListBadges();
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
    private void AddNewBadge() { }
    private void EditBadge() { }
    private void ViewBadges() { }
    public void SeedMenu()
    {
        Badge firstBadge = new Badge(12345, new List<string>());
        Badge secondBadge = new Badge(22345, new List<string>());
        Badge thirdBadge = new Badge(32345, new List<string>());

        _repo.CreateNewBadge(firstBadge);
        _repo.CreateNewBadge(secondBadge);
        _repo.CreateNewBadge(thirdBadge);


    }
}
