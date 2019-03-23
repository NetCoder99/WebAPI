using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Models.Security
{
    //[Table("AspNetRoles", Schema = "Security")]
    public class AspNetRoles : IdentityRole
    {

        [Display(Name = "Role Id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Index("IX_RoleId", IsUnique = true)]
        public int RoleId { get; set; }

        [Display(Name = "Role Description")]
        [StringLength(50)]
        public string Description { get; set; }

        [Display(Name = "Create Date")]
        public DateTime CreateDate { get; set; }

        [Display(Name = "User Count")]
        [NotMapped]
        public int UserCount { get; set; }

    }
}