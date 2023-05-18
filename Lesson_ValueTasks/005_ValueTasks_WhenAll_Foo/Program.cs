using System;
using System.Threading.Tasks;

namespace _005_ValueTasks_WhenAll_Foo
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            //await Test_Foo();
            //await Test_Fix_1();
            await Test_Fix_2();

            Console.WriteLine("Finish");
            Console.ReadLine();
        }

        private static Task Test_Foo()
        {
            return Task.WhenAll(
                Task.Run(() => ReturnValueTask(1)),
                Task.Run(() => ReturnValueTask(2)));
        }

        private static Task Test_Fix_1()
        {
            return Task.WhenAll(
                Task.Run(async () => await ReturnValueTask(1)),
                Task.Run(async () => await ReturnValueTask(2)));
        }

        private static Task Test_Fix_2()
        {
            return Task.WhenAll(
                Task.Run(() => ReturnValueTask(1).AsTask()),
                Task.Run(() => ReturnValueTask(2).AsTask()));
        }

        private static async ValueTask ReturnValueTask(int id)
        {
            await Task.Delay(100);
            Console.WriteLine(id);
        }
    }
}
