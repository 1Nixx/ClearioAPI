using API.DTOs;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.OrderService;
using Core.Specification;
using Infrastructure.Quartz;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class OrderController : ControllerBase
	{
		private readonly IGenericRepository<Order> _context;
		private readonly IMapper _mapper;
		private readonly IOrderService _orderService;
		public OrderController(IGenericRepository<Order> context, IMapper mapper, IOrderService orderService)
		{
			_context = context;
			_mapper = mapper;
			_orderService = orderService;
		}

		[HttpGet("all")]
		public async Task<ActionResult<IReadOnlyList<OrderShortInfo>>> GetAllOrders()
		{
			var spec = new OrdersWithObjectData();
			var orderList = await _context.ListAsync(spec);

			return Ok(_mapper.Map<IReadOnlyList<Order>, IReadOnlyList<OrderShortInfo>>(orderList));
		}

		[HttpPost("add")]
		public async Task AddOrder([FromBody] OrderBaseInfo order)
		{
			await _orderService.AddOrderAsync(order);
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<Order>> GetOrderFullInfo(int id)
		{
			var spec = new OrderWithFullInfo(id);

			var order = await _context.GetEntityWithSpec(spec);
			return Ok(order);
		}

		[HttpPost("newcleaner/{id}")]
		public async Task AddCleanerToOrder(int id,[FromQuery] int cleanerId)
		{
			await _orderService.AddNewCleanerToOrderAsync(id, cleanerId);
		}

		[HttpPost("changestatus/{id}")]
		public async Task ChangeOrderStatus(int id, [FromQuery] int newStatus)
		{
			await _orderService.ChangeOrderStatus(id, newStatus);
		}
	}
}
