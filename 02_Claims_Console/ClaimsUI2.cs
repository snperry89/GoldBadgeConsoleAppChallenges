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
            /// formatting doesn't look right
            /// need to look more into formatting columns/tables???
           
            string headerSize = "{0,-10}{1,-8}{2,-30}{3,-10}{4,-18}{5,-15}{6,-10}";

            Console.Write("\t");
            Console.Write(headerSize, "Claim ID", "Type", "Description", "Amount", "Date Of Incident", "Date Of Claim", "Is Valid\n\n");
            //Console.WriteLine($"Claim ID"  +
            //        $"Claim Type"   +
            //        $"Claim Description"  +
            //        $"Claim Amount" +
            //        $"Date Of Incident"  +
            //        $"Date Of Claim"  +
            //        $"Is Claim Valid");
            foreach (Claims claim in allClaims)
            {
                Console.Write("\t");
                Console.Write(headerSize,
                  $"{claim.ClaimID}", 
                  $"{claim.TypeOfClaim}", 
                  $"{claim.Description}", 
                  $"${claim.ClaimAmount}", 
                  $"{claim.DateOfIncident.ToShortDateString()}", 
                  $"{claim.DateOfClaim.ToShortDateString()}", 
                  $"{claim.IsValid}\n\n");
                // look into .shortdatetostring more, removes hour/min/sec from DateTime
            }
        }
        private void TakeCareOfNextClaim()
        {
            Console.Clear();
            Claims nextClaim = _repo.PeekNextClaim();
            Console.WriteLine($"The next claim in the queue is ");
            Console.WriteLine($"Claim ID: {nextClaim.ClaimID}\n" +
                    $"Claim Type: {nextClaim.TypeOfClaim}\n" +
                    $"Claim Description: {nextClaim.Description}\n" +
                    $"Claim Amount: {nextClaim.ClaimAmount}\n" +
                    $"Date Of Incident: {nextClaim.DateOfIncident.ToShortDateString()}\n" +
                    $"Date Of Claim: {nextClaim.DateOfClaim.ToShortDateString()}\n" +
                    $"Is Claim Valid: {nextClaim.IsValid}\n");

            Console.WriteLine("Do you want to deal with this claim now(y/n)?");
            ///if y-dequeue  if n then back to the menu...
            string s = (Console.ReadLine().ToLower());
            if (s == "y")
            {
                _repo.DequeueClaim(nextClaim);
                Console.WriteLine("The claim was successfully handled.");
            }
            if (s == "n")
            {
                Console.WriteLine($"The claim will remain in the queue.");

            }
            else
            {
                Console.WriteLine("Please enter a valid input.");
            }
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

            Console.WriteLine("Please enter date of incident for new claim with the following format: yyyy, mm, dd:");
            claim.DateOfIncident = Convert.ToDateTime(Console.ReadLine());

            Console.WriteLine("Please enter date of new claim with the following format: yyyy, mm, dd:");
            claim.DateOfClaim = Convert.ToDateTime(Console.ReadLine());

            TimeSpan isClaimValid = claim.DateOfClaim - claim.DateOfIncident;
            double daysSince = isClaimValid.TotalDays;
            if (daysSince <= 30)
            {
                claim.IsValid = true;
            }
            else
            {
                claim.IsValid = false;
            }
            //claim not successfully added
            _repo.CreateNewClaim(claim);

        }
        public void SeedMenu()
        {
            Claims firstClaim = new Claims(1, ClaimType.Car, "Car accident on 465.", 400.00m, new DateTime(2018, 04, 25), new DateTime(2018, 04, 27), true);
            Claims secondClaim = new Claims(2, ClaimType.Home, "House fire in the kitchen.", 4000.00m, new DateTime(2018, 04, 11), new DateTime(2018, 04, 12), true);
            Claims thirdClaim = new Claims(3, ClaimType.Theft, "Stolen donuts.", 4.00m, new DateTime(2018, 04, 27), new DateTime(2018, 06, 01), false);

            _repo.CreateNewClaim(firstClaim);
            _repo.CreateNewClaim(secondClaim);
            _repo.CreateNewClaim(thirdClaim);

        }
    }
}
