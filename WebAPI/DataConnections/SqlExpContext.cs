﻿using System.Configuration;
using System.Data.Entity;
using WebAPI.Models;

namespace WebAPI.DataConnections
{
    public class SqlExpContext : DbContext
    {

        public SqlExpContext()
        { this.Database.Connection.ConnectionString = GetSqlConnectionStr(); }

        public DbSet<CountryCode>  CountryCodes { get; set; }
        public DbSet<StateCode>    StateCodes   { get; set; }

        private static string GetSqlConnectionStr()
        {
            var c1 = ConfigurationManager.ConnectionStrings["AdWorks16Exp"];
            return c1.ConnectionString;
        }

    }
}