using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _015_Exceptions.Extensions
{
    public static class ObjectExtensions
    {
        public static int TryCatchToInt32(this string num)
        {
            try
            {
                return Convert.ToInt32(num);
            }
            catch
            {
                return default(int);
            }
        }

        public static int ToInt32(this string num)
        {
            int n;
            int.TryParse(num, out n);
            return n;
        }
    }
}