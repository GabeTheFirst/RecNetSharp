using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecNetSharp
{
    internal static class RequestTools
    {
        public static string CreateQueryArray(string Query, List<long> Items)
        {
            string Result = "?";
            foreach(var Item in Items)
            {
                Result += Query + "=" + Item.ToString() + "&";
            }
            Result = Result.TrimEnd('&');
            return Result;
        }
    }
}
