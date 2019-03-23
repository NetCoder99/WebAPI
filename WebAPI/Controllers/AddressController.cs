﻿using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using WebAPI.Common;
using WebAPI.DataConnections;
using WebAPI.Models;
using WebAPI.Models.Accounts;
using WebAPI.Models.Security;

namespace WebAPI.Controllers
{
    public class AddressController : ApiController
    {
        [HttpGet]
        [Route("api/Address/LoadCountries")]
        public IEnumerable<CountryCode> LoadCountries()
        { return LoadCountries("json", true); }
        [HttpGet]
        [Route("api/Address/LoadCountries/{source}")]
        public IEnumerable<CountryCode> LoadCountries(string source, bool truncate)
        {
            string jsonDataDir = CommonFileProcs.GetLocalDirectory("JsonData");
            string jsonData = CommonFileProcs.GetAllRecords(jsonDataDir, "Countries.json");
            List<CountryCode> rtn_list = CommonJSONProcs.ProcessJSONClass<CountryCode>(jsonData);
            using (var db_con = new SqlLclContext())
            {
                if (truncate) { DBFunctions.Truncate<CountryCode>(db_con); }
                db_con.CountryCodes.AddRange(rtn_list);
                db_con.SaveChanges();
                return db_con.CountryCodes.ToList();
            }
        }


        [HttpGet]
        [Route("api/Address/LoadStates")]
        public IEnumerable<StateCode> LoadStates()
        { return LoadStates("json", true); }
        [HttpGet]
        [Route("api/Address/LoadStates/{source}")]
        public IEnumerable<StateCode> LoadStates(string source, bool truncate)
        {
            string jsonDataDir = CommonFileProcs.GetLocalDirectory("JsonData");
            string jsonData = CommonFileProcs.GetAllRecords(jsonDataDir, "States.json");
            List<StateCode> rtn_list = CommonJSONProcs.ProcessJSONClass<StateCode>(jsonData);
            using (var db_con = new SqlLclContext())
            {
                if (truncate)
                { DBFunctions.Truncate<StateCode>(db_con); }
                db_con.StateCodes.AddRange(rtn_list);
                db_con.SaveChanges();
                return db_con.StateCodes.ToList();
            }
        }




        [HttpGet]
        [Route("api/Address/GetCountries/")]
        public IEnumerable<CountryCode> GetCountries()
        {
            string jsonDataDir = CommonFileProcs.GetLocalDirectory("JsonData");
            string jsonData = CommonFileProcs.GetAllRecords(jsonDataDir, "Countries.json");
            return CommonJSONProcs.ProcessJSONClass<CountryCode>(jsonData);
        }

        [HttpGet]
        [Route("api/Address/GetCountries/{abbr}")]
        public IEnumerable<CountryCode> GetCountries(string abbr)
        {
            string jsonDataDir = CommonFileProcs.GetLocalDirectory("JsonData");
            string jsonData = CommonFileProcs.GetAllRecords(jsonDataDir, "Countries.json");
            List<CountryCode> rtn_list = CommonJSONProcs.ProcessJSONClass<CountryCode>(jsonData);
            return rtn_list.Where(w=>w.CountryAbbr == abbr);
        }

        [HttpGet]
        [Route("api/Address/GetStates")]
        public IEnumerable<StateCode> GetStates()
        {
            using (var db_con = new SqlLclContext())
            {
                List<StateCode> rtn_obj = db_con.StateCodes.ToList();
                return rtn_obj;
            }
        }
        [HttpGet]
        [Route("api/Address/GetStates/{code}")]
        public IEnumerable<StateCode> GetStates(string code)
        {
            using (var db_con = new SqlExpContext())
            {
                CountryCode countryCode = db_con.CountryCodes.FirstOrDefault(f => f.CountryAbbr.ToUpper() == code.ToUpper());
                List< StateCode> rtn_obj = db_con.StateCodes.Where(w => w.CountryCodeId == countryCode.CountryCodeId).ToList();
                return rtn_obj;
            }
        }

        [HttpGet]
        [Route("api/Address/GetUsers")]
        public IEnumerable<UserDetailJson> GetUsers()
        {
            string jsonDataDir = CommonFileProcs.GetLocalDirectory("JsonData");
            string jsonData = CommonFileProcs.GetAllRecords(jsonDataDir, "UserAccountInitList.json");
            List<UserDetailJson> rtn_list = CommonJSONProcs.ProcessJSONClass<UserDetailJson>(jsonData);
            return rtn_list;
        }
        [HttpGet]
        [Route("api/Address/LoadUsers")]
        public IEnumerable<UserDetailJson> LoadUsers()
        {
            string jsonDataDir = CommonFileProcs.GetLocalDirectory("JsonData");
            string jsonData = CommonFileProcs.GetAllRecords(jsonDataDir, "UserAccountInitList.json");
            List<UserDetailJson> rtn_list = CommonJSONProcs.ProcessJSONClass<UserDetailJson>(jsonData);

            using (var db_con = new SqlExpIdentity())
            {
                var users = db_con.Users.ToList();
                foreach (UserDetailJson json_user in rtn_list)
                {
                    AspNetUser ident_user = new AspNetUser(json_user);
                    db_con.Users.Add(ident_user);
                }
                try
                {
                    int row_cnt = db_con.SaveChanges();
                }
                catch
                {
                    var errors = db_con.GetValidationErrors();
                    var errorList = CommonErrorProcs.ExtractValidationErrors(db_con);
                }
            }

            return rtn_list;
        }


    }
}
