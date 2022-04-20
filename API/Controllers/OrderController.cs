using API.DTOs;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specification;
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
		public OrderController(IGenericRepository<Order> context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		[HttpGet("all")]
		public async Task<ActionResult<IReadOnlyList<OrderShortInfo>>> GetAllOrders()
		{
			var spec = new OrdersWithObjectData();
			var orderList = await _context.ListAsync(spec);
			
			return Ok(_mapper.Map<IReadOnlyList<Order>, IReadOnlyList<OrderShortInfo>>(orderList));
		}

		[HttpPost("add")]
		public Task AddOrder()
		{

		}

	}
}
