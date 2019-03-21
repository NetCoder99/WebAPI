using System.Configuration;
using System.Data.Common;
using System.Data.Entity;
using System.Data.SqlClient;
using WebAPI.Models;
using WebApp2.Models.Addresses;

namespace WebAPI.DataConnections
{
    public class SqlExpContext : DbContext
    {

        public SqlExpContext()
        {
            this.Database.Connection.ConnectionString = GetSqlConnectionStr();
        }

        public DbSet<CountryCode>  CountryCodes { get; set; }
        public DbSet<StateCode>    StateCodes   { get; set; }

        private static string GetSqlConnectionStr()
        {
            var c1 = ConfigurationManager.ConnectionStrings["WebApp2Exp"];
            return c1.ConnectionString;
            //return new SqlConnection(c1.ConnectionString);
        }

    }
}