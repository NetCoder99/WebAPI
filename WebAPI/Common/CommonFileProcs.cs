using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI.Common
{
    class CommonFileProcs
    {

        // ---------------------------------------------------------------------------------------
        // this only works when you have an override of ToString() in the List<class>
        // ---------------------------------------------------------------------------------------
        public static void DisplayList<T>(List<T> any_list)
        {
            Console.WriteLine("----- {0} -----", typeof(T).Name);
            foreach (var list_item in any_list)
            { Console.WriteLine(list_item.ToString()); }
        }

        // ---------------------------------------------------------------------------------------
        // get all records, as a single string
        // ---------------------------------------------------------------------------------------
        public static string GetAllRecords(string jsonDir, string jsonFile)
        {
            return File.ReadAllText(jsonDir + "\\" + jsonFile);
        }

        // ---------------------------------------------------------------------------------------
        // recursively backtrack from the base dir until we find the directory we're looking for
        // ---------------------------------------------------------------------------------------
        public static string GetLocalDirectory(string srch_dir, DirectoryInfo p1 = null)
        {

            if (p1 == null)
            {
                p1 = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory).Parent;
                return GetLocalDirectory(srch_dir, p1);
            }
            //Console.WriteLine(p1.FullName);
            //this is for unathorized directories, when you hit one simply skip over it
            try
            {
                if (p1.GetDirectories(srch_dir, SearchOption.AllDirectories).Length > 0)
                {
                    return p1.GetDirectories(srch_dir, SearchOption.AllDirectories)[0].FullName;
                }
            }
            catch 
            { }

            if (p1.Parent == null)
            {
                throw new Exception("Local Directory for JSON data not found: " + srch_dir);
            }
            return GetLocalDirectory(srch_dir, p1.Parent);
        }
    }
}
