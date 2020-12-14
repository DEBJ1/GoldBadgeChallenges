using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeTwo.Repo
{
    public class ClaimContentRepo
    {
        

        private Queue<ClaimContent> _claimQueue = new Queue<ClaimContent>();
        

        //create
        public void AddClaimToQueue(ClaimContent claim)
        {
            _claimQueue.Enqueue(claim);
        }
        //read
        public Queue<ClaimContent> GetClaimQueue()
        {
            return _claimQueue;
        }

       //take care of (delete)
       public bool RemoveClaim()
        {
            ClaimContent content = _claimQueue.Peek();
            if (content == null)
            {
                return false;
            }

            int intialCount = _claimQueue.Count;
            _claimQueue.Dequeue();

            if(intialCount > _claimQueue.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

       


    //helper method 
    public ClaimContent GetClaimByID(int id)
        {
            foreach(ClaimContent content in _claimQueue)
            {
                if(content.ClaimID == id)
                {
                    return content;
                }
            }
            return null;
        }

}
}
