using System;

namespace _005_Attributes_Currency
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //CultureInfo ci = new CultureInfo("hy-AM");
            //CultureInfo ci = new CultureInfo("en-US");

            decimal price = 25.25697M;

            string v = price.ToString("C", new System.Globalization.CultureInfo("hy-AM"));

            string value = price.ToCurrency(RateType.Usd);
            string valueAmd = price.ToCurrency(RateType.Amd);
            string valueRu = price.ToCurrency(RateType.Rub);
            string valueAre = price.ToCurrency(RateType.Are);

            Console.ReadLine();
        }
    }
}
