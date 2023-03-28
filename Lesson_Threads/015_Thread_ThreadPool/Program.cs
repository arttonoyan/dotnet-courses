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
            ShowThreadInfo();

            Console.ReadLine();

            var student = new Student { Id = 12, Name = "A1" };
            ThreadPool.QueueUserWorkItem(BackgroundTask, student);
            ShowThreadInfo();

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

        static void ShowThreadInfo()
        {
            ThreadPool.GetAvailableThreads(out int availableWorkThreads, out int completionPortThreads);
            ThreadPool.GetMaxThreads(out int maxWorkThreads, out int maxCompletionPortThreads);
            Console.WriteLine("-------------Available Work Threads: {0} from {1}", availableWorkThreads, maxWorkThreads);
        }

    }

    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
