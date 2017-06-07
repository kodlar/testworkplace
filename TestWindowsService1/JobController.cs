using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quartz;
using Quartz.Impl;

namespace TestWindowsService1
{
    public class JobController
    {
        public void Work()
        {
            try
            {
               
                StdSchedulerFactory factory = new StdSchedulerFactory();
                // get a scheduler
                IScheduler sched = factory.GetScheduler();

                sched.Start();

                // define the job and tie it to our HelloJob class
                IJobDetail job = JobBuilder.Create<ParseJob>().WithIdentity("SoccerDailyMatches", "SoccerGroup").Build();
                IJobDetail job2 = JobBuilder.Create<LogJob>().WithIdentity("SoccerDailyMatchesLog", "SoccerGroup").Build();
                // Trigger the job to run now, and then every 40 seconds
                ITrigger trigger =
                    TriggerBuilder.Create()
                                  .WithIdentity("SoccerDailyMatchesTrigger", "SoccerGroup")
                                  .StartNow()
                                  .WithSimpleSchedule(x => x.WithIntervalInSeconds(10).RepeatForever())                                                                    
                                  .Build();
                ITrigger trigger2 =
                    TriggerBuilder.Create()
                                  .WithIdentity("SoccerDailyMatchesLogTrigger", "SoccerGroup")
                                  .StartNow()
                                  .WithSimpleSchedule(x => x.WithIntervalInSeconds(10).RepeatForever())
                                  .Build();

                sched.ScheduleJob(job, trigger);
                sched.ScheduleJob(job2, trigger2);
            }
            catch (SchedulerException se)
            {

                Console.WriteLine(se);
            }

        }
    }
}
