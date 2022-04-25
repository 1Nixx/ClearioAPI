using Infrastructure.Quartz.Jobs;
using Microsoft.Extensions.DependencyInjection;
using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Quartz
{
    public static class OrderStatusScheduler
    {
		public static async Task OrderStartCleaning(int orderId, DateTime startTime, IServiceProvider serviceProvider)
		{
			IScheduler scheduler = await StdSchedulerFactory.GetDefaultScheduler();
			scheduler.JobFactory = serviceProvider.GetService<JobFactory>();
			await scheduler.Start();

			var timeAmount = startTime - DateTime.Now;
			var resultTime = DateTime.Now + timeAmount;

			IJobDetail jobDetail = JobBuilder.Create<StartOrderJob>().UsingJobData("orderId", orderId).Build();
			ITrigger trigger = TriggerBuilder.Create()
				.WithIdentity($"order {orderId}", "startCleaning")
				.StartAt(resultTime)
				.ForJob(jobDetail)
				.Build();

			await scheduler.ScheduleJob(jobDetail, trigger);
		}

		public static async Task OrderEndCleaning(int orderId, DateTime finishTime, IServiceProvider serviceProvider)
		{
			IScheduler scheduler = await StdSchedulerFactory.GetDefaultScheduler();
			scheduler.JobFactory = serviceProvider.GetService<JobFactory>();
			await scheduler.Start();

			var timeAmount = finishTime - DateTime.Now;
			var resultTime = DateTime.Now + timeAmount;

			IJobDetail jobDetail = JobBuilder.Create<FinishOrderJob>().UsingJobData("orderId", orderId).Build();
			ITrigger trigger = TriggerBuilder.Create()
				.WithIdentity($"order {orderId}", "finishCleaning")
				.StartAt(resultTime)
				.WithSimpleSchedule(s => s
					.WithRepeatCount(5)
					.WithIntervalInSeconds(10))
				.ForJob(jobDetail)
				.Build();

			await scheduler.ScheduleJob(jobDetail, trigger);
		}

		public static async Task OrderForciblyEnd(int orderId, DateTime finishTime, IServiceProvider serviceProvider)
		{
			IScheduler scheduler = await StdSchedulerFactory.GetDefaultScheduler();
			scheduler.JobFactory = serviceProvider.GetService<JobFactory>();
			await scheduler.Start();

			var timeAmount = finishTime - DateTime.Now;
			var resultTime = DateTime.Now + timeAmount + TimeSpan.FromSeconds(80);

			IJobDetail jobDetail = JobBuilder.Create<ForcedFinishJob>().UsingJobData("orderId", orderId).Build();
			ITrigger trigger = TriggerBuilder.Create()
				.WithIdentity($"order {orderId}", "forciblyCleaning")
				.StartAt(resultTime)
				.ForJob(jobDetail)
				.Build();

			await scheduler.ScheduleJob(jobDetail, trigger);
		}
	}
}
