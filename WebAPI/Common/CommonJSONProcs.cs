using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using WebAPI.Models;
using WebApp2.Models.Addresses;
using static WebApp2.Models.Addresses.CountryCode;

namespace WebAPI.Common
{
    class CommonJSONProcs
    {

        // ---------------------------------------------------------------------------------------
        // messing around with Generics and JSON
        // ---------------------------------------------------------------------------------------
        public static List<T> ProcessJSONClass<T>(string json_string)
        {
            Type type = typeof(T);

            if (type == typeof(CountryCode))
            {
                var root = JsonConvert.DeserializeObject<CountryCodeRoot>(json_string);
                List<CountryCode> sf_list = new List<CountryCode>();
                sf_list.AddRange(root.Country);
                List<T> rtn_list = sf_list.Cast<T>().ToList();
                return rtn_list;
            }

            if (type == typeof(UserAccount))
            {
                var root = JsonConvert.DeserializeObject<UserAccountRoot>(json_string);
                List<UserAccount> sf_list = new List<UserAccount>();
                sf_list.AddRange(root.UserAccount);
                List<T> rtn_list = sf_list.Cast<T>().ToList();
                return rtn_list;
            }
            if (type == typeof(UserField))
            {
                var root = JsonConvert.DeserializeObject<UserAccountRoot>(json_string);
                List<UserAccount> root_list = new List<UserAccount>();
                List<UserField> flds_list = new List<UserField>();
                root_list.AddRange(root.UserAccount);
                flds_list.AddRange(root_list[0].UserFields);
                List<T> rtn_list = flds_list.Cast<T>().ToList();
                return rtn_list;
            }
            if (type == typeof(UserDetail))
            {
                var root = JsonConvert.DeserializeObject<UserAccountRoot>(json_string);
                List<UserAccount> root_list = new List<UserAccount>();
                List<UserDetail> dtls_list = new List<UserDetail>();
                root_list.AddRange(root.UserAccount);
                dtls_list.AddRange(root_list[0].UserDetails);
                List<T> rtn_list = dtls_list.Cast<T>().ToList();
                return rtn_list;
            }
            throw new Exception("Unknow type");
        }
    }
}
