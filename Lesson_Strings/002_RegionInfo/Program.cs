using System;
using System.Globalization;

namespace _002_RegionInfo
{
    class Program
    {
        static void Main(string[] args)
        {
            var ri = new RegionInfo("hy-AM");

            // Get info about current region
            RegionInfo regionInfo = RegionInfo.CurrentRegion;
            Console.WriteLine("EnglishName:\t{0}.", regionInfo.EnglishName);
            Console.WriteLine("NativeName:\t{0}.", regionInfo.NativeName);

            Console.WriteLine(new string('-', 35));

            Console.WriteLine("CurrencySymbol:\t{0}", regionInfo.CurrencySymbol);
            Console.WriteLine("CurrencyEnglishName:\t{0}", regionInfo.CurrencyEnglishName);
            Console.WriteLine("CurrencyNativeName:\t{0}", regionInfo.CurrencyNativeName);

            Console.WriteLine(new string('-', 35));

            // Get information about the current date format: names of days.
            string[] days = CultureInfo.CurrentCulture.DateTimeFormat.DayNames;

            Console.WriteLine("Days of the week:");
            foreach (string day in days)
            {
                Console.WriteLine(day);
            }

            Console.WriteLine(new string('-', 35));

            // Getting information about the date format in Armenian: names of days.
            days = CultureInfo.GetCultureInfo("hy-AM").DateTimeFormat.DayNames;

            Console.WriteLine("Days of the week in German:");
            foreach (string day in days)
            {
                Console.WriteLine(day);
            }

            // Delay.
            Console.ReadKey();
        }
    }
}
