using System.Collections.Specialized;
using System.Diagnostics;
using System.ServiceProcess;
using System.Threading.Tasks;
using Quartz;
using Quartz.Impl;

namespace TestWindowsService1
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            if (Debugger.IsAttached)
            {
                Common.Logging.LogManager.Adapter = new Common.Logging.Simple.ConsoleOutLoggerFactoryAdapter { Level = Common.Logging.LogLevel.Info };
                //Debug.WriteLine("holaaaa!....");
                JobController jobs = new JobController();
                jobs.Work();
                // construct a scheduler factory
               
            }
            else
            {
                ServiceBase[] ServicesToRun;
                ServicesToRun = new ServiceBase[]
                {
                new Service1()
                };
                ServiceBase.Run(ServicesToRun);
            }


        }


       
    }
}
