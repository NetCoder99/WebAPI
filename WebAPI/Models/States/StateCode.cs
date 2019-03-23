//============================================================================
// John Dugger
// 02/27/2019
// Define the db fields for the States name dropdowns/lists, etc. Keep 
// this simple as it maps to the DB Tables and changing this leads
// to migration issues in the EF, which I don't want to deal with now.
//============================================================================
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Models
{

    [Table("StateCodes", Schema = "Common")]
    public class StateCode 
    {
        [Key]
        public int StateCodeId { get; set; }

        [Required]
        [MaxLength(2)]
        [Index]
        public string StateAbbr { get; set; }

        [Required]
        [MaxLength(128)]
        public string StateName { get; set; }

        [Required]
        public DateTime LoadDate { get; set; }

        public StateCode() { }
        public StateCode(int country_id, string state_abbr, string state_name)
        {
            this.CountryCodeId = country_id;
            this.StateAbbr = state_abbr.Trim();
            this.StateName = state_name.Trim();
            this.LoadDate = DateTime.Now;
        }

        public int CountryCodeId { get; set; }

        public class StateCodeRoot 
        {
            public List<StateCode> States { get; set; }
        }
    }
}