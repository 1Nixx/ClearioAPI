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
		Task AddNewCleanerToOrderAsync(int orderId, int newCleaner);

		Task ChangeOrderStatus(int orderId, int statusId);
	}
}
