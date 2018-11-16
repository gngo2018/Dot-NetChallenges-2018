using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_2
{
    public class Claim
    {
        public int ClaimID { get; set; }
        public bool IsValid { get; set; }
        public decimal ClaimAmount { get; set; }
        public string ClaimType { get; set; }
        public string Description { get; set; }
        public string DateOfIncident { get; set; }
        public string DateOfClaim { get; set; }

        public Claim(int claimID, bool isValid, decimal claimAmount, string claimType, string description, string dateOfAccident, string dateOfClaim)
        {
            ClaimID = claimID;
            IsValid = isValid;
            ClaimAmount = claimAmount;
            ClaimType = claimType;
            Description = description;
            DateOfIncident = DateOfIncident;
            DateOfClaim = dateOfClaim;

        }

        public Claim()
        {

        }
    }
}
