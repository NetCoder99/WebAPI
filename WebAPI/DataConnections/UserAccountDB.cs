using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Linq;
using WebAPI.Models;

namespace WebAPI.DataConnections
{
    class UserAccountDB : DbContext
    {
        public UserAccountDB(DbConnection sql_con) : base(sql_con, true) { }
        public DbSet<UserDetail> UserDetails { get; set; }
    }
}
