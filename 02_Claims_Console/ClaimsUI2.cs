using _02_Claims_Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Claims_Console
{
    class ClaimsUI2
    {
        private ClaimsRepo2 _repo = new ClaimsRepo2();
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
                Console.WriteLine("Select an option:\n" +
                    "1. View all claims\n" +
                    "2. Take care of next claim\n" +
                    "3. Create new claim\n" + 
                    "4. Exit");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        ViewAllClaims();
                        break;
                    case "2":
                        TakeCareOfNextClaim();
                        break;
                    case "3":
                        AddNewClaim();
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
        private void ViewAllClaims()
        {
            Console.Clear();
            Queue<Claims> allClaims = _repo.GetClaims();
            foreach (Claims claim in allClaims)
            {
                Console.WriteLine($"Claim ID: {claim.ClaimID}\n" +
                    $"Claim Type: {claim.TypeOfClaim}\n" +
                    $"Claim Description: {claim.Description}\n" +
                    $"Claim Amount: {claim.ClaimAmount}\n" +
                    $"Date Of Incident: {claim.DateOfIncident}\n" +
                    $"Date Of Claim: {claim.DateOfClaim}\n" +
                    $"Is Claim Valid: {claim.IsValid}");

            }
        }
        private void TakeCareOfNextClaim()
        {
            Console.Clear();
            ViewAllClaims();
            Console.WriteLine("Do you want to deal with this claim now(y/n)?");
            bool enqueueClaim = Convert.ToInt32(_repo.DequeueClaim(Console.ReadLine()));
        }
        private void AddNewClaim()
        {
            Console.Clear();
            Claims claim = new Claims();
            Console.WriteLine("Please enter new claim ID: ");
            claim.ClaimID = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please select claim type:\n" +
                "Car = 1, Home = 2, Theft = 3");
            int typeAsInt = Convert.ToInt32(Console.ReadLine());
            claim.TypeOfClaim = (ClaimType)typeAsInt;
            Console.WriteLine("Please enter description of new claim: ");
            claim.Description = Console.ReadLine();
            Console.WriteLine("Please enter amount of new claim: ");
            claim.ClaimAmount = Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine("Please enter date of incident for new claim: ");
            claim.DateOfIncident = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("Please enter date of new claim: ");
            claim.DateOfClaim = Convert.ToDateTime(Console.Read());
            _repo.CreateNewClaim(claim);
            
        }
        private void SeedMenu()
        {
            Claims First = new Claims(1, ClaimType.Car, "Car accident on 465.", 400.00m, new DateTime(2018, 04, 25), new DateTime(2018, 04, 27), true);
            Claims Second = new Claims(2, ClaimType.Home, "House fire in the kitchen.", 4000.00m, new DateTime(2018, 04, 11), new DateTime(2018, 04, 12), true);
            Claims Third = new Claims(3, ClaimType.Theft, "Stolen donuts.", 4.00m, new DateTime(2018, 04, 27), new DateTime(2018, 06, 01), false);

            _repo.AddItemToQueue(First);
            _repo.AddItemToQueue(Second);
            _repo.AddItemToQueue(Third);

        }
    }
}
