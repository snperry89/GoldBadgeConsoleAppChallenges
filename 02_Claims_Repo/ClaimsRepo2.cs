using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Claims_Repo
{
    public class ClaimsRepo2
    {
        private readonly Queue<Claims> _claims = new Queue<Claims>();
        //Create
        public bool CreateNewClaim(Claims newClaim)
        {
            int startingCount = _claims.Count;
            _claims.Enqueue(newClaim);
            bool wasAdded = (_claims.Count > startingCount) ? true : false;
            return wasAdded;
        }
        //Read
        public Queue<Claims> GetClaims()
        {
            return _claims;
        }
        //Read by value-claimID
        public Claims GetClaimByID(int claimID)
        {
            foreach (Claims claim in _claims)
            {
                if (claim.ClaimID == claimID)
                {
                    return claim;
                }
            }
            return null;
        }
        //Update
        //Delete
        public bool DequeueClaim(int claimToDequeue)
        {
            Claims claimToRemove = GetClaimByID(claimToDequeue);
            if (claimToRemove == null)
            {
                return false;
            }
            else
            {
                _claims.Enqueue(claimToRemove);// shouldnt this be dequeue?
                return true;
            }
        }

    }
}
