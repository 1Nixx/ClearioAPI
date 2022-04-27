using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using API.DTOs;

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
		}

		// GET: api/<CleaningObjectController>
		[HttpGet("{id}")]
		public async Task<ActionResult<CleaningObject>> GetCleaningObject(int id)
		{
			return await _context.GetByIdAsync(id);
		}
		
		[HttpPost("add")]
		public async Task AddCleaningObject(CleaningObject cleaningObject)
		{
			await _context.AddEntityAsync(cleaningObject);
		}

		[HttpGet("all")]
		public async Task<ActionResult<IReadOnlyList<CleaningObjectShortInfo>>> GetAllObjects()
		{
			var objectList = await _context.ListAllAsync();
			return Ok(_mapper.Map<IReadOnlyList<CleaningObject>, IReadOnlyList<CleaningObjectShortInfo>>(objectList));
		}

		[HttpDelete("delete/{id}")]
		public async Task DeleteObject(int id)
		{
			await _context.DeleteByIdAsync(id);
		}


	}
}
