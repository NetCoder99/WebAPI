using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebAPI.Common;
using WebAPI.Models.Accounts;

namespace WebAPI.Models.Security
{
    [Table("AspNetUser", Schema = "Security")]
    public class AspNetUser : IdentityUser
    {
        [Display(Name = "User ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }

        [Display(Name = "Email Address")]
        [Index(IsUnique = true)]
        [StringLength(50)]
        public override string Email { get; set; }

        [Display(Name = "Password")]
        [StringLength(50)]
        [NotMapped]
        public string Password { get; set; }

        [Display(Name = "Password Confirmation")]
        [StringLength(50)]
        [NotMapped]
        public string PasswordConfirm { get; set; }

        [Display(Name = "First Name")]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [StringLength(50)]
        public string LastName { get; set; }

        [Display(Name = "Display Name")]
        [StringLength(50)]
        public string DisplayName { get; set; }

        [Display(Name = "Notify Email")]
        public bool PrefEmail { get; set; }

        [Display(Name = "Notify Text")]
        public bool PrefText { get; set; }

        [Display(Name = "Create Date")]
        public DateTime CreateDate { get; set; }

        public AspNetUser() { }

        public AspNetUser(UserDetailJson detailJson)
        {
            UserName = detailJson.email;
            Email = detailJson.email;
            FirstName = detailJson.FirstName;
            LastName = detailJson.LastName;
            DisplayName = detailJson.Name;
            PhoneNumber = detailJson.Phone;
            PrefEmail = (detailJson.PrefEmail == 1) ? true: false;
            PrefText = (detailJson.PrefText == 1) ? true : false;
            CreateDate = DateTime.Now;
            PasswordHash = HashFunctions.HashPassword(detailJson.Password);
            SecurityStamp = Guid.NewGuid().ToString("D");
        }

    }
}