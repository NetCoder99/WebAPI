using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using WebAPI.Models;
using WebAPI.Models.Accounts;
using WebAPI.Models.Misc;

namespace WebAPI.Common
{
    class CommonJSONProcs
    {

        //public static GetParms ProcessGetParms(JToken jToken)
        //{
        //    var root = JsonConvert.DeserializeObject<GetParms>(json_string);
        //    return root;
        //}

        // ---------------------------------------------------------------------------------------
        // messing around with Generics and JSON
        // ---------------------------------------------------------------------------------------
        public static List<T> ProcessJSONClass<T>(string json_string) 
        {
            Type type = typeof(T);

            if (type == typeof(StateCode))
            {
                var root = JsonConvert.DeserializeObject<StateCode.StateCodeRoot>(json_string);
                List<StateCode> sf_list = new List<StateCode>();
                sf_list.AddRange(root.States);
                List<T> rtn_list = sf_list.Cast<T>().ToList();
                return rtn_list;
            }
            
            if (type == typeof(CountryCode))
            {
                //List<CountryCode> tmp_list = JsonConvert.DeserializeObject<List<CountryCode>>(json_string);
                //List<T> rtn_list = tmp_list.Cast<T>().ToList();
                //return rtn_list;

                var root = JsonConvert.DeserializeObject<CountryCode.CountryCodeRoot>(json_string);
                List<CountryCode> sf_list = new List<CountryCode>();
                var rootData = root.Country;
                sf_list.AddRange(root.Country);

                List<T> rtn_list = sf_list.Cast<T>().ToList();
                return rtn_list;
            }

            //if (type == typeof(UserAccount))
            //{
            //    var root = JsonConvert.DeserializeObject<UserAccountRoot>(json_string);
            //    List<UserAccount> sf_list = new List<UserAccount>();
            //    sf_list.AddRange(root.UserAccount);
            //    List<T> rtn_list = sf_list.Cast<T>().ToList();
            //    return rtn_list;
            //}
            //if (type == typeof(UserField))
            //{
            //    var root = JsonConvert.DeserializeObject<UserAccountRoot>(json_string);
            //    List<UserAccount> root_list = new List<UserAccount>();
            //    List<UserField> flds_list = new List<UserField>();
            //    root_list.AddRange(root.UserAccount);
            //    flds_list.AddRange(root_list[0].UserFields);
            //    List<T> rtn_list = flds_list.Cast<T>().ToList();
            //    return rtn_list;
            //}
            if (type == typeof(UserDetailJson))
            {
                var root = JsonConvert.DeserializeObject<UserAccountRootJson>(json_string);
                List<UserAccountJson> root_list = new List<UserAccountJson>();
                List<UserDetailJson> dtls_list = new List<UserDetailJson>();
                root_list.AddRange(root.UserAccount);
                dtls_list.AddRange(root_list[0].UserDetails);
                List<T> rtn_list = dtls_list.Cast<T>().ToList();
                return rtn_list;
            }
            throw new Exception("Unknow type");
        }
    }
}
