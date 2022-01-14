using System;

namespace _011_Exceptions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                try
                {
                    try
                    {
                        throw new Exception("My Exception.");
                    }
                    catch
                    {
                        Console.WriteLine("Catch 1.");
                        throw;
                    }
                    finally
                    {
                        Console.WriteLine("Finally 1.");
                    }
                }
                catch
                {
                    Console.WriteLine("Catch 2.");
                    throw;
                }
                finally
                {
                    Console.WriteLine("Finally 2.");
                }
            }
            catch
            {
                Console.WriteLine("Catch 3.");
            }
            finally
            {
                Console.WriteLine("Finally 3.");
            }

            Console.ReadLine();
        }
    }
}
