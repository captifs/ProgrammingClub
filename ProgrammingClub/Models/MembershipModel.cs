using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProgrammingClub.Models
{
    public class MembershipModel
    {
        public Guid IDMembership { get; set; }
        public Guid IDMember { get; set;  }
        public Guid IDMembershipType { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int Level { get; set; }
  }
}