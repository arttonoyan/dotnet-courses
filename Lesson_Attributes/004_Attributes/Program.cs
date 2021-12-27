using System;
using System.Diagnostics;
using System.Reflection;

namespace _004_Attributes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var test = new Test();

            test.Initialize();
            test.Trial();   // Called only if TRIAL identifier is defined
            test.Release(); // Called only if RELEASE identifier is defined
            Console.WriteLine(new string('-', 20));

            Type type = typeof(Test);

            MethodInfo[] methodInfo = type.GetMethods(
                BindingFlags.Public |         // Indicates that public members should be included in the search.
                BindingFlags.NonPublic |      // Specifies that non-public instance members should be included in the search.
                BindingFlags.Instance |       // Specifies that non-public instance members should be included in the search.
                BindingFlags.DeclaredOnly);   // Specifies that only members declared at the hierarchy level of the passed type should be considered. Inherited members are not counted.

            foreach (MethodInfo method in methodInfo)
            {
                Console.WriteLine(method.Name);
            }

            // Delay.
            Console.ReadKey();
        }
    }

    internal class Test
    {
        [Conditional("TRIAL")]
        internal void Trial()
        {
            Console.WriteLine("Trial Version.");
        }

        [Conditional("PREMIUM")]
        internal void Release()
        {
            Console.WriteLine("Premium Version.");
        }

#if DEBUG
        public void Initialize()
        {
            Console.WriteLine("Application Initialization in DEBUG mode.");
        }
#else
        public void Initialize()
        {
            Console.WriteLine("Application Initialization in RELEASE mode.");
        }
#endif
    }
}
