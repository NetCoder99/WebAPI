using Microsoft.AspNet.Identity.EntityFramework;
using System.Configuration;
using System.Data.Entity;
using WebAPI.Models;
using WebAPI.Models.Security;

namespace WebAPI.DataConnections
{

    public class SqlLclIdentity : IdentityDbContext<AspNetUser, AspNetRoles, string, IdentityUserLogin, IdentityUserRole, IdentityUserClaim>
    {

        public SqlLclIdentity() 
        { this.Database.Connection.ConnectionString = GetSqlConnectionStr(); }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasDefaultSchema("Security");
        }

        private static string GetSqlConnectionStr()
        {
            var c1 = ConfigurationManager.ConnectionStrings["AdWorks16Lcl"];
            return c1.ConnectionString;
        }

    }
}