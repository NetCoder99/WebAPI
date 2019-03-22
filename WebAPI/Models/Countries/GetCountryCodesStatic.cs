using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models.Countries
{
    public class GetCountryCodesStatic
    {
        public static List<CountryCode> GetStateCodes()
        {
            List<CountryCode> rtn_list = new List<CountryCode>();
            rtn_list.Add(new CountryCode(1, "MEX", "Mexico"));
            rtn_list.Add(new CountryCode(2, "CAN", "Canada"));
            rtn_list.Add(new CountryCode(3, "USA", "United States"));
            return rtn_list;
        }

    }
}

