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
        //No Update Method necessary in prompt???
        
        // need method to peek in queue
        public Claims PeekNextClaim()
        {
            Claims claimToPeek = _claims.Peek(); 

            return claimToPeek;       
        }
        //Delete AKA next claim
        public bool DequeueClaim(Claims nextClaim)
        {
            Claims claimToRemove = nextClaim;
            if (claimToRemove != null)
            {
                _claims.Dequeue();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
