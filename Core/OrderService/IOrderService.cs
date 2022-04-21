using Core.Entities;
using Core.OrderService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.OrderService
{
	public interface IOrderService
	{
		Task AddOrderAsync(OrderBaseInfo orderInfo);
		OrderStatus UpdateOrderStatus(int orderId);
		Task AddNewCleanerToOrderAsync(int orderId, int newCleaner);
	}
}
