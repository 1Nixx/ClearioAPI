using Core.Entities;
using Core.Interfaces;
using Core.Specification;
using Microsoft.Extensions.DependencyInjection;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Quartz.Jobs
{
    public class ForcedFinishJob : IJob
    {
        private readonly IServiceScopeFactory serviceScopeFactory;
        public ForcedFinishJob(IServiceScopeFactory serviceScopeFactory)
        {
            this.serviceScopeFactory = serviceScopeFactory;
        }

        public async Task Execute(IJobExecutionContext context)
        {
            using var scope = serviceScopeFactory.CreateScope();
            var _orderRepository = scope.ServiceProvider.GetService<IGenericRepository<Order>>();

            var orderId = context.JobDetail.JobDataMap.GetIntValue("orderId");
            var order = await _orderRepository.GetByIdAsync(orderId);

            if (order is null)
                return;

            if (order.OrderStatus != OrderStatus.CleaningFinished)
			{
                order.OrderStatus = OrderStatus.FinishedForcibly;
                await _orderRepository.UpdateEntityAsync(order);
			}
        }
    }
}
