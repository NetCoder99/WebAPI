using System.Collections.Generic;

namespace WebAPI.Models.States
{
    public class GetStateCodesStatic
    {
        public static List<StateCode> GetStateCodes()
        {
            List<StateCode> rtn_list = new GetStateCodesCAN().GetStates();
            rtn_list.AddRange(new GetStateCodesMEX().GetStates());
            rtn_list.AddRange(new GetStateCodesUSA().GetStates());
            return rtn_list;
        }
    }
}