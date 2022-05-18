using System;
using System.Linq;
using System.Threading.Tasks;

namespace _002_ValueTasks
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var myService = new MyService();
            var res_my = await myService.GetAsyncTasks(10).ToListAsync_ValueTask();

            var res = await myService.GetAsyncTasks(10).ToListAsync();
        }
    }
}
