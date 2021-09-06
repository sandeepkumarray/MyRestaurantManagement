using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyRestaurantManagement.Helpers
{
    public class Utility
    {
        public static string CartCountValue(string count)
        {
            if (!string.IsNullOrEmpty(count))
            {
                int count_Int = Convert.ToInt32(count);
                return count;
            }
            else
                return "0";
        }
    }
}
