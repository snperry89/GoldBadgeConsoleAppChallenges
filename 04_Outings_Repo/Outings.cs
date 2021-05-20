using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_Outings_Repo
{
    
    
    /// POCO
    public enum EventType { Golf =1, Bowling, AmusementPark, Concert}
    public class Outings
    {
        public int AmtAttended { get; set; }
        public EventType TypeOfEvent { get; set; }
        public DateTime DateOfEvent { get; set; }
        public decimal CostPerPerson { get; set; }
        public decimal EventCost { get; set; }

        public Outings() { }
        public Outings( int amtAttended, EventType typeOfEvent, DateTime dateOfEvent, decimal costPerPerson, decimal eventCost)
        {
            AmtAttended = amtAttended;
            TypeOfEvent = typeOfEvent;
            DateOfEvent = dateOfEvent;
            CostPerPerson = costPerPerson;
            EventCost = eventCost;
        }
    }
}
