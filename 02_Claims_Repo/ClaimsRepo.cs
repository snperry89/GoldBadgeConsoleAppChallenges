using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Claims_Repo
{
    public class ClaimsRepo // goal is to hold all CRUD
        //Repo acts as holder of data and manipulator of data
    {
        private Queue<Claims> _listOfClaims = new Queue<Claims>();
        //Create
        public void AddClaim(Claims claim)
        {
            _listOfClaims.Enqueue(claim);
        }
        //Read
        public Queue<Claims> ViewClaims()
        {
            return _listOfClaims;
        }
        //Update
        public bool UpdateClaim(int originalClaimID, Claims newClaim)
        {
            //Find claim
            Claims oldClaim = ViewClaimByClaimID(originalClaimID);
            //Update claim
            if (oldClaim != null)
            {
                oldClaim.ClaimID = newClaim.ClaimID;
                oldClaim.TypeOfClaim = newClaim.TypeOfClaim;
                oldClaim.Description = newClaim.Description;
                oldClaim.ClaimAmount = newClaim.ClaimAmount;
                oldClaim.DateOfIncident = newClaim.DateOfIncident;
                oldClaim.DateOfClaim = newClaim.DateOfClaim;
                oldClaim.IsValid = newClaim.IsValid;
                return true;
            }
            else
            {
                return false;
            }
        }

        //Delete
        public bool DeleteClaim(int claimID)
        {
            Claims claim = ViewClaimByClaimID(claimID);
            if (claim == null)
            {
                return false;
            }
            int initialCount = _listOfClaims.Count;
            _listOfClaims.Enqueue(claim); // shouldnt this be dequeue
            if (initialCount > _listOfClaims.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //Helper Method
        public Claims ViewClaimByClaimID(int claimID)
        {
            foreach(Claims claim in _listOfClaims)
            { 
                if(claim.ClaimID == claimID)
                {
                    return claim;
                }
            }
            return null;
        }
    }
}
