﻿//============================================================================
// John Dugger
// 03/02/2019
// Several of the 'lists' that I use my apps are static, they rarely, if 
// ever, change and they will never be updated by the application. 
//============================================================================
using System;
using System.Collections.Generic;
using System.Linq;
using WebAPI.DataConnections;
using WebApp2.Models.Addresses;

namespace WebAPI.Models
{
    //class StateCodeList 
    //{
    //    private static List<StateCode> _StateCodesList = new List<StateCode>();

    //    public static void Initialize(StateCodesDB states_db)
    //    { _StateCodesList = states_db.StateCodes.ToList(); }

    //    public static List<StateCode> Get()
    //    { return _StateCodesList; }

    //    public static List<StateCode> Get(CountryCode country_code)
    //    { return _StateCodesList.Where(w => w.CountryCodeId == country_code.CountryCodeId).ToList(); }

    //    public static List<StateCode> Get(string country_abbr)
    //    {
    //        int country_id = CountryCodeList.Get().Where(w => w.CountryAbbr == country_abbr).First().CountryCodeId;
    //        return _StateCodesList.Where(w => w.CountryCodeId == country_id).ToList();
    //    }

    //}
}
