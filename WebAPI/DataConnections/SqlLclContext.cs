﻿using Microsoft.AspNet.Identity.EntityFramework;
using System.Configuration;
using System.Data.Entity;
using WebAPI.Models;
using WebAPI.Models.Security;

namespace WebAPI.DataConnections
{
    public class SqlLclContext : DbContext
    {

        public SqlLclContext() 
        { this.Database.Connection.ConnectionString = GetSqlConnectionStr(); }

        public DbSet<CountryCode>  CountryCodes { get; set; }
        public DbSet<StateCode>    StateCodes   { get; set; }

        private static string GetSqlConnectionStr()
        {
            var c1 = ConfigurationManager.ConnectionStrings["AdWorks16Lcl"];
            return c1.ConnectionString;
        }

    }
}