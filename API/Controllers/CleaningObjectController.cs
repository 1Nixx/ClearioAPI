using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using API.DTOs;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CleaningObjectController : ControllerBase
	{
		private readonly IGenericRepository<CleaningObject> _context;
		private readonly IMapper _mapper;
		public CleaningObjectController(IGenericRepository<CleaningObject> context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
			_mapper = mapper;
		}


		// GET: api/<CleaningObjectController>
		[HttpGet("{id}")]
		public async Task<ActionResult<CleaningObject>> GetCleaningObject(int id)
		{
			return await _context.GetByIdAsync(id);
		}
		
		[HttpPost("add")]
		public async Task AdddCleaningObject(CleaningObject cleaningObject)
		{
			await _context.AddEntityAsync(cleaningObject);
		}

		[HttpGet("/all")]
		public async Task<ActionResult<IReadOnlyList<CleaningObject>>> GetAllObjects()
		{
			var objectList = await _context.ListAllAsync();
			return Ok(_mapper.Map<IReadOnlyList<CleaningObject>, IReadOnlyList<CleaningObjectShortInfo>>(objectList));
		}


	}
}
