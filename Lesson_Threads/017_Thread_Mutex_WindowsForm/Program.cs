using System;
using System.Threading;
using System.Windows.Forms;

namespace _017_Thread_Mutex_WindowsForm
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            const string appName = "Lesson SingletonApp";
            using (var mutex = new Mutex(false, appName, out bool isNotCreated))
            {
                if(isNotCreated)
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new Form1());
                }
            }

            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());
        }
    }
}
