using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeTwo.Repo
{

    public enum ClaimType
    {
        Car = 1,
        Home,
        Theft,

    }

   

    public class ClaimContent
    {
        public int ClaimID { get; set; }
        public ClaimType TypeOfClaim { get; set; }
        public string Description { get; set; }
        public int ClaimAmount { get; set; }
        public DateTime DateOfIncident { get; set; }
        public bool IsValid { get; set; }

        public ClaimContent() { }

        public ClaimContent(int id, ClaimType type, string description, int amount, DateTime date, bool isValid)
        {
            ClaimID = id;
            TypeOfClaim = type;
            Description = description;
            ClaimAmount = amount;
            DateOfIncident = date;
            IsValid = isValid;
        }


    }
}
