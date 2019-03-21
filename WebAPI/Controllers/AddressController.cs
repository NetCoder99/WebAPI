using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Common;
using WebAPI.DataConnections;
using WebAPI.Models;
using WebApp2.Models.Addresses;

namespace WebAPI.Controllers
{
    public class AddressController : ApiController
    {
        [Route("api/Address/GetCountries/")]
        public IEnumerable<CountryCode> GetCountries()
        {
            string jsonDataDir = CommonFileProcs.GetLocalDirectory("JsonData");
            string jsonData = CommonFileProcs.GetAllRecords(jsonDataDir, "Countries.json");
            return CommonJSONProcs.ProcessJSONClass<CountryCode>(jsonData);
        }

        [Route("api/Address/GetCountries/{abbr}")]
        public IEnumerable<CountryCode> GetCountries(string abbr)
        {
            string jsonDataDir = CommonFileProcs.GetLocalDirectory("JsonData");
            string jsonData = CommonFileProcs.GetAllRecords(jsonDataDir, "Countries.json");
            return CommonJSONProcs.ProcessJSONClass<CountryCode>(jsonData).Where(w=>w.CountryAbbr == abbr);
        }

        [Route("api/Address/GetStates")]
        public IEnumerable<StateCode> GetStates()
        {
            using (var db_con = new SqlExpContext())
            {
                List<StateCode> rtn_obj = db_con.StateCodes.ToList();
                return rtn_obj;
            }
        }

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

    }
}
