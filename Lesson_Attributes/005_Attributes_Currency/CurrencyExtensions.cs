using System.Globalization;
using System.Reflection;

namespace _005_Attributes_Currency
{
    public static class CurrencyExtensions
    {
        public static string ToCurrency(this decimal value, RateType rt)
        {
            string cName = rt.GetCultureName();
            var ci = new CultureInfo(cName);
            return value.ToString("C", ci);
        }

        public static string GetCultureName(this RateType rt)
        {
            var members = typeof(RateType).GetMember(rt.ToString());
            var ria = members[0].GetCustomAttribute<RateInfoAttribute>();
            if(ria == null)
                throw new CultureNotFoundException();

            return ria.CultureName;
        }
    }
}
