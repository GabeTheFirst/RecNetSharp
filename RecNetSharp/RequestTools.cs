using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecNetSharp
{
    internal static class RequestTools
    {
        // creates a query string that's a list (array) of items with the 'Query' variable as the variable
        public static string CreateQueryArray(string Query, List<long> Items)
        {
            // the string that eventually gets returned
            string Result = "?";

            // foreac item in the list of longs (most likely id in this case)
            foreach(var Item in Items)
            {
                // add to query string the Query=Value&
                Result += Query + "=" + Item.ToString() + "&";
            }
            // trim the last &
            Result = Result.TrimEnd('&');

            // return the completed string
            return Result;
        }
    }
}
