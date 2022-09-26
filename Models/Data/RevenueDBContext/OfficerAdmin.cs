using System;
using System.Collections.Generic;

#nullable disable

namespace RevenueApp.Models.Data.RevenueDBContext
{
    public partial class OfficerAdmin
    {
        public int StaffId { get; set; }
        public int ImageId { get; set; }
        public int GenderId { get; set; }
        public string OfficerEmail { get; set; }
        public int RankId { get; set; }
        public string OfficerFname { get; set; }
        public string OfficerLname { get; set; }
        public DateTime OfficerDoB { get; set; }
        public string OfficerResidentialAddress { get; set; }
        public string OfficerDigitalAddress { get; set; }
        public string OfficerContact { get; set; }
        public string OfficerNextOfKin { get; set; }
        public string OfficerNextOfKinContact { get; set; }
        public int RelationId { get; set; }
        public int TitleId { get; set; }
        public int AssemblyId { get; set; }

        public virtual Assembly Assembly { get; set; }
        public virtual Gender Gender { get; set; }
        public virtual Image Image { get; set; }
        public virtual OfficeRank Rank { get; set; }
        public virtual Relation Relation { get; set; }
        public virtual Title Title { get; set; }
    }
}
