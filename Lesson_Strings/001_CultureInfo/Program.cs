using System;
using System.Globalization;

namespace _001_CultureInfo
{
    // CultureInfo Class
    // https://docs.microsoft.com/en-us/dotnet/api/system.globalization.cultureinfo?redirectedfrom=MSDN&view=net-6.0

    // Standard Date and Time Format Strings
    // https://docs.microsoft.com/ru-ru/dotnet/standard/base-types/standard-date-and-time-format-strings?redirectedfrom=MSDN
    class Program
    {
        static void Main(string[] args)
        {
            // Get Info about current culture
            CultureInfo currentCulture = CultureInfo.CurrentCulture;
            Console.WriteLine("Current Culture: {0}.", currentCulture);

            // Get information about all cultures in system
            CultureInfo[] cultureInfo = CultureInfo.GetCultures(CultureTypes.NeutralCultures);
            Console.WriteLine("{0} different cultures in the system.", cultureInfo.Length);

            foreach (CultureInfo ci in cultureInfo)
            {
                Console.WriteLine(ci.EnglishName + " | " + ci.ToString());
            }

            //var specificCultures = new List<string>
            //{
            //    "hy-AM",
            //    "ru-RU",
            //    "en-US",
            //    "en-US",
            //    "ar-AE"
            //};

            //string cn = "hy-AM";
            //var armCultureInfo = new CultureInfo(specificCultures[0]);
            //string info = DateTime.Now.ToString("D", armCultureInfo.DateTimeFormat);
            //string info1 = string.Format("{0} {1}", armCultureInfo.NumberFormat.CurrencySymbol, 235.6);
            //string info2 = 235.6.ToString("C", armCultureInfo);

            // Delay.
            Console.ReadKey();
        }
    }

    public enum RateType
    {
        amd = 1,
        usd,
        eur,
        rub,
        /// <summary>
        /// <para>Arab Emirates Dirham</para>
        /// <para>United Arab Emirates</para>
        /// </summary>
        aed
    }
}
