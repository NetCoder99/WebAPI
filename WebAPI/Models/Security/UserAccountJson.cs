using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models.Accounts
{
    public class UserFieldJson
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public bool Key { get; set; }
        public string Length { get; set; }
    }

    public class UserDetailJson
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public string email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public int PrefEmail { get; set; }
        public int PrefText { get; set; }
    }

    public class UserAccountJson
    {
        public List<UserFieldJson> UserFields { get; set; }
        public List<UserDetailJson> UserDetails { get; set; }
    }

    public class UserAccountRootJson
    {
        public List<UserAccountJson> UserAccount { get; set; }
    }
}