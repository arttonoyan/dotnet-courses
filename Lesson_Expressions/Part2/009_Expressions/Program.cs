using _000_DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace _009_Expressions
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var sw = Stopwatch.StartNew();

            List<Blog> blogs1 = Dapper.Execute<Blog>("select * from Blogs").ToList();
            Console.WriteLine($"Count: {blogs1.Count}");
            Log(sw.Elapsed);
            sw = Stopwatch.StartNew();

            List<Blog> blogs2 = Dapper.Execute<Blog>("select * from Blogs").ToList();
            Log(sw.Elapsed);
            sw = Stopwatch.StartNew();

            List<Blog> blogs3 = Dapper.Execute<Blog>("select * from Blogs").ToList();
            Log(sw.Elapsed);
            sw = Stopwatch.StartNew();

            List<Blog> blogs4 = Dapper.Execute<Blog>("select * from Blogs").ToList();
            Log(sw.Elapsed);

            Console.ReadLine();
        }

        static void Log(TimeSpan ts)
        {
            string elapsedTime = string.Format("{0:00}:{1:00}:{2:00}.{3:0000000}",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds);
            Console.WriteLine("RunTime " + elapsedTime);
        }
    }
}
