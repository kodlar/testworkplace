using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quartz;

namespace TestWindowsService1
{
    public class LogJob : IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            Console.Out.WriteLineAsync("Log Job is executing." + DateTime.Now);
        }
    }
}
