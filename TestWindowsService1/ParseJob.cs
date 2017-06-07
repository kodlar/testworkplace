using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Quartz;

namespace TestWindowsService1
{
    public class ParseJob : IJob
    {
        
        void IJob.Execute(IJobExecutionContext context)
        {
            Console.Out.WriteLineAsync("Parse Job is executing." + DateTime.Now);           
        }
    }
}