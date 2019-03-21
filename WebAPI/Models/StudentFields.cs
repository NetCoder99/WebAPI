﻿//============================================================================
// John Dugger
// 03/03/2019
// Generated by this web site, added some code for null int's.
// http://json2csharp.com/
//============================================================================
using System.Collections.Generic;

namespace WebAPI.Models
{
    public class StudentField
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public int Length { get; set; }
        public override string ToString()
        {
            return  Name + "," + Type + "," + Length.ToString();
        }
    }

    public class StudentFieldRoot
    {
        public List<StudentField> StudentFields { get; set; }
    }
}
