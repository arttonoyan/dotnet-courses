using System;
using System.Threading;

namespace _015_Thread_ThreadPool
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Main Thread: {Thread.CurrentThread.ManagedThreadId}");
            ThreadPool.QueueUserWorkItem(state =>
            {
                Console.WriteLine($"Child thread: {Thread.CurrentThread.ManagedThreadId}, State - '{state}'");
            });

            //Console.ReadLine();

            var student = new Student { Id = 12, Name = "A1" };
            ThreadPool.QueueUserWorkItem(BackgroundTask, student);

            Console.ReadLine();
        }

        static void BackgroundTask(object state)
        {
            string stateInfo = "";

            var student = state as Student;
            if (student != null)
                stateInfo = "{ " + $"Id={student.Id}, Name={student.Name}" + " }";

            Console.WriteLine($"Child thread: {Thread.CurrentThread.ManagedThreadId}, State - '{stateInfo}'");
        }
    }

    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
