namespace VicGenesis2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class VicTown
    {
        public int Id { get; set; }

        public string COMM_CODE { get; set; }

        public string Community_Name { get; set; }

        public string Funded_services { get; set; }

        public string HACC_services { get; set; }

        public string Health_or_Human_services { get; set; }

        public string Dental_sites { get; set; }

        public string Primary_schools { get; set; }

        public string Distance_Service { get; set; }

        public string Number_of_households { get; set; }

        public string Rank_funded { get; set; }

        public string Rank_HACC { get; set; }

        public string Rank_HH_services { get; set; }

        public string Rank_dental { get; set; }

        public string Rank_school { get; set; }

        public string Rank_distance { get; set; }

        public string Rank_household { get; set; }
    }
}
