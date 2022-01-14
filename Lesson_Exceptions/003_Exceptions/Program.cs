using System;
using System.Collections;

namespace _003_Exceptions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var instance = new MyClass();
            try
            {
                instance.Method();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.TargetSite);
                Console.WriteLine(ex.TargetSite.DeclaringType);
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.Source);
                Console.WriteLine(ex.HelpLink);
                Console.WriteLine(ex.StackTrace);

                foreach (DictionaryEntry item in ex.Data)
                {
                    Console.WriteLine("{0} : {1}", item.Key, item.Value);
                }
            }

            Console.ReadLine();
        }
    }

    class MyClass
    {
        public void Method()
        {
            Exception ex = new Exception("My exception");
            ex.HelpLink = "http://mic.am/ErrorService";
            ex.Data.Add("Reason", "Test Exception");
            ex.Data.Add("Date", DateTime.Now);

            throw ex;
        }
    }
}
