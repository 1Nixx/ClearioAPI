using Core.Entities;
using Core.Interfaces;
using Core.Specification;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Quartz.Jobs
{
    public class FinishOrderJob : IJob
    {
        private readonly IServiceScopeFactory serviceScopeFactory;
        public FinishOrderJob(IServiceScopeFactory serviceScopeFactory)
        {
            this.serviceScopeFactory = serviceScopeFactory;
        }

        public async Task Execute(IJobExecutionContext context)
        {
            using var scope = serviceScopeFactory.CreateScope();
            var _orderRepository = scope.ServiceProvider.GetService<IGenericRepository<Order>>();

            var orderId = context.JobDetail.JobDataMap.GetIntValue("orderId");

            var spec = new OrderWithCleaners(orderId);
            var order = await _orderRepository.GetEntityWithSpec(spec);

            bool AllFinished = true;
			foreach (var cleaner in order.Cleaners)
			{
				if (cleaner.IsStartingWorking && !cleaner.IsFinishedWorking)
				{
                    AllFinished = false;
                    break;
				}
			}
            
            if (AllFinished)
			{
                order.OrderStatus = OrderStatus.CleaningFinished;
                await _orderRepository.UpdateEntityAsync(order);

                await context.Scheduler.DeleteJob(context.JobDetail.Key);
			}
        }
    }
}
