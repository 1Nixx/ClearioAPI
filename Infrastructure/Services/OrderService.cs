﻿using Core.CleanerRepository;
using Core.Entities;
using Core.Interfaces;
using Core.OrderService;
using Core.Specification;
using Infrastructure.Quartz;
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
		private readonly IServiceProvider _serviceProvider;
		public OrderService(IGenericRepository<Order> orderRepository, ICleanerRepository cleanerRepository, IServiceProvider serviceProvider)
		{
			_orderRepository = orderRepository;
			_cleanerRepository = cleanerRepository;
			_serviceProvider = serviceProvider;
		}

		public async Task AddNewCleanerToOrderAsync(int orderId, int newCleaner)
		{
			var spec = new OrderWithCleaners(orderId);
			var order = await _orderRepository.GetEntityWithSpec(spec);
			order.Cleaners.Add(GetTeamMember(await _cleanerRepository.GetCleanerByIdAsync(newCleaner)));
			order.OrderStatus = OrderStatus.CleaningInProcess;
			await _orderRepository.UpdateEntityAsync(order);
		}

		public async Task AddOrderAsync(OrderBaseInfo orderInfo)
		{
			var order = await ConvertOrderBaseInfoToOrderAsync(orderInfo);
			await _orderRepository.AddEntityAsync(order);

			OrderStatusScheduler.OrderStartCleaning(order.Id, order.TimeStart, _serviceProvider);
			OrderStatusScheduler.OrderEndCleaning(order.Id, order.TimeEnd, _serviceProvider);
			OrderStatusScheduler.OrderForciblyEnd(order.Id, order.TimeEnd, _serviceProvider);
		}

		public async Task ChangeOrderStatus(int orderId, int statusId)
		{
			var order = await _orderRepository.GetByIdAsync(orderId);
			order.OrderStatus = (OrderStatus)statusId;
			await _orderRepository.UpdateEntityAsync(order);
		}

		public async Task DeleteOrderAsync(int orderId)
		{
			var spec = new OrderWithCleaners(orderId);
			await _orderRepository.DeleteWithSpec(spec);
		}

		private async Task<Order> ConvertOrderBaseInfoToOrderAsync(OrderBaseInfo baseInfo)
		{
			var order = new Order();
			order.CleaningObjectId = baseInfo.ObjectId;
			order.TimeStart = baseInfo.TimeStart;
			order.TimeEnd = baseInfo.TimeEnd;
			order.OrderStatus = OrderStatus.WaitingCleaningBeninings;
			order.Cleaners = new List<CleanTeamMember>(baseInfo.CleanerId.Count);
			for (int i = 0; i < baseInfo.CleanerId.Count; i++)
				order.Cleaners.Add(GetTeamMember(await _cleanerRepository.GetCleanerByIdAsync(baseInfo.CleanerId[i])));

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
