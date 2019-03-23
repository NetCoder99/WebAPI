using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;

namespace WebAPI.Common
{
    public class CommonErrorProcs
    {

        public static List<Tuple<string, string>> ExtractValidationErrors(DbContext dbContext)
        {
            List<Tuple<string, string>> rtnList = new List<Tuple<string, string>>();
            foreach (DbEntityValidationResult err in dbContext.GetValidationErrors())
            {
                DbValidationError dbError = err.ValidationErrors.ToList()[0];
                rtnList.Add(new Tuple<string, string>(dbError.PropertyName, dbError.ErrorMessage));
            }
            return rtnList;
        }


    }
}