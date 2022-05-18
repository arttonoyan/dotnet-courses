using System;
using System.Threading.Tasks;

namespace _005_ValueTasks_WhenAll_Foo
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            await Test_Foo();

            Console.ReadLine();
        }

        private static async Task Test_Foo()
        {
            await Task.WhenAll(
                Task.Run(() => ReturnValueTask(1)),
                Task.Run(() => ReturnValueTask(2)));

            Console.WriteLine("Finish");
        }

        private static async Task Test_Fix_1()
        {
            await Task.WhenAll(
                Task.Run(async () => await ReturnValueTask(1)),
                Task.Run(async () => await ReturnValueTask(2)));

            Console.WriteLine("Finish");
        }

        private static async Task Test_Fix_2()
        {
            await Task.WhenAll(
                Task.Run(() => ReturnValueTask(1).AsTask()),
                Task.Run(() => ReturnValueTask(2).AsTask()));

            Console.WriteLine("Finish");
        }

        private static async ValueTask ReturnValueTask(int id)
        {
            await Task.Delay(100);
            Console.WriteLine(id);
        }
    }
}
