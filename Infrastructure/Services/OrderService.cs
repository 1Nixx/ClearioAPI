using Core.Entities;
using Core.Interfaces;
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
		public OrderService(IGenericRepository<Order> orderRepository)
		{
			_orderRepository = orderRepository;
		}

	}
}
