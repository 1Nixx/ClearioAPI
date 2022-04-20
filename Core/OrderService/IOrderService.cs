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
		void AddOrder(OrderBaseInfo orderInfo);
		OrderStatus UpdateOrderStatus(int orderId);
		void AddNewCleanerToOrder(int orderId, int newCleaner);
	}
}
