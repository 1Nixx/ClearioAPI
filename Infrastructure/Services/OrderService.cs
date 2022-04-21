using Core.CleanerRepository;
using Core.Entities;
using Core.Interfaces;
using Core.OrderService;
using Core.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
	public class OrderService : IOrderService
	{
		private readonly IGenericRepository<Order> _orderRepository;
		private readonly ICleanerRepository _cleanerRepository;
		public OrderService(IGenericRepository<Order> orderRepository, ICleanerRepository cleanerRepository)
		{
			_orderRepository = orderRepository;
			_cleanerRepository = cleanerRepository;
		}

		public async Task AddNewCleanerToOrderAsync(int orderId, int newCleaner)
		{
			var spec = new OrderWithCleaners(orderId);
			var order = await _orderRepository.GetEntityWithSpec(spec);
			order.Cleaners.Add(GetTeamMember(_cleanerRepository.GetCleanerById(newCleaner)));
			await _orderRepository.UpdateEntityAsync(order);
		}

		public async Task AddOrderAsync(OrderBaseInfo orderInfo)
		{
			var order = ConvertOrderBaseInfoToOrder(orderInfo);
			await _orderRepository.AddEntityAsync(order);
#warning Add Delayed update
		}

		public OrderStatus UpdateOrderStatus(int orderId)
		{
			throw new NotImplementedException();
		}

		private Order ConvertOrderBaseInfoToOrder(OrderBaseInfo baseInfo)
		{
			var order = new Order();
			order.CleaningObjectId = baseInfo.ObjectId;
			order.TimeStart = baseInfo.TimeStart;
			order.TimeEnd = baseInfo.TimeEnd;
			order.OrderStatus = OrderStatus.WaitingCleaningBeninings;
			order.Cleaners = new List<CleanTeamMember>(baseInfo.CleanerId.Count);
			for (int i = 0; i < baseInfo.CleanerId.Count; i++)
				order.Cleaners.Add(GetTeamMember(_cleanerRepository.GetCleanerById(baseInfo.CleanerId[i])));

			return order;
		}

		private CleanTeamMember GetTeamMember(CleanerInfo cleanerInfo)
		{
			var teamMember = new CleanTeamMember();	
			teamMember.CleanerName = cleanerInfo.CleanerName;
			teamMember.PhoneNumber = cleanerInfo.PhoneNumber;
			teamMember.CleanerId = cleanerInfo.CleanerId;

			return teamMember;
		}
	}
}
