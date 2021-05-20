using _04_Outings_Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_Outings_Console
{
    class OutingsUI
    {
        private OutingsRepo _repo = new OutingsRepo();
        public void Run()
        {
            SeedMenu();
            Menu();
        }


        public void SeedMenu()
        {
            Outings firstOuting = new Outings(100, EventType.AmusementPark, new DateTime(2021, 05, 20), 20.50m, 2050m);
            Outings secondOuting = new Outings(200, EventType.Golf, new DateTime(2021, 04, 28), 10m, 2000m);
            Outings thirdOuting = new Outings(50, EventType.Bowling, new DateTime(2021, 03, 15), 7.25m, 362.5m);
        }

        
    }
}
