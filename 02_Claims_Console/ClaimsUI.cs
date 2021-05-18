using _02_Claims_Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Claims_Console
{
    class ClaimsUI
    {
        private ClaimsRepo _repo = new ClaimsRepo();
        public void Run()
        {
            EnqueueClaims();
            Menu();
        }
        public void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.Clear();
                Console.WriteLine("Select a menu option:\n" +
                    "1. See all claims\n" +
                    "2. Take care of next claim\n" +
                    "3. Enter a new claim\n" +
                    "4. Exit program");

                string input = Console.ReadLine();
                switch(input)
                {
                    case "1":
                        ViewAllClaims();
                        break;
                    //case "2":
                    //    TakeCareOfNextClaim();
                    //    break;
                    case "3":
                        EnterNewClaim();
                        break;
                    case "4":
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid option");
                        break;
             

                }
                Console.WriteLine("Please press any key to continue:");
                Console.Read();
                Console.Clear();
                Menu();
            }
        }
        private void ViewAllClaims()
        {
            Console.Clear();
            Queue<Claims> allClaims = _repo.ViewClaims();
            foreach (Claims claim in allClaims)
            {
                Console.WriteLine($"Claim ID: {claim.ClaimID}\n" +
                    $"Claim Type: {claim.TypeOfClaim}\n" +
                    $"Description: {claim.Description}\n" +
                    $"Claim Amount: {claim.ClaimAmount}\n" +
                    $"Date Of Accident: {claim.DateOfIncident}\n" +
                    $"Date Of Claim: {claim.DateOfClaim}" +
                    $"Claim Is Valid: {claim.IsValid}\n");
            }
        }
        //private void TakeCareOfNextClaim()
        //{
        //    ViewAllClaims();
        //    Queue<Claims> listOfClaims = new Queue<Claims>();
        //    listOfClaims.Enqueue(claim);
        //    Claims First = listOfClaims.Dequeue();
        //}
        public void EnterNewClaim()
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
            _repo.EnqueueClaim(claim);
            Console.Clear();
        }
        private void EnqueueClaims()
        {
            Claims First = new Claims(1, ClaimType.Car, "Car accident on 465", 400.00m, new DateTime(2018, 04, 18), new DateTime(2018, 04, 27), true);
            Claims Second = new Claims(2, ClaimType.Home, "House fire in the kitchen", 4000.00m, new DateTime(2018, 04, 11), new DateTime(2018, 04, 12), true);
            Claims Third = new Claims(3, ClaimType.Theft, "Stolen donuts", 4.00m, new DateTime(2018, 04, 27), new DateTime(2018, 06, 01), false);

            _repo.EnqueueClaim(First);
            _repo.EnqueueClaim(Second);
            _repo.EnqueueClaim(Third);
        }
        
    } 
}
