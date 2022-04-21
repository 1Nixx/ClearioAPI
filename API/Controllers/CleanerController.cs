using Core.CleanerNotificationService;
using Core.CleanerRepository;
using Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CleanerController : ControllerBase
	{
		private readonly ICleanerNotificationService _cleanerNotification;
		private readonly ICleanerRepository _cleanerRepository;
		public CleanerController(ICleanerNotificationService cleanerNotification, ICleanerRepository cleanerRepository)
		{
			_cleanerNotification = cleanerNotification;
			_cleanerRepository = cleanerRepository;	
		}

		[HttpPost("update")]
		public async Task CleanerIsComing(CleanerNotificationInfo cleanerInfo)
		{
			await _cleanerNotification.UpdateCleanerConditionAsync(cleanerInfo);
		}

		[HttpGet("all")]
		public async Task<List<CleanerInfo>> GetAllCleaners()
		{
			return await _cleanerRepository.GetAllCleanersAsync();
		}

		[HttpGet("allbyaddress")]
		public async Task<List<CleanerInfo>> GetAllCleanersByAddress(string address)
		{
			return await _cleanerRepository.GetALLCleanersByAddressAsync(address);
		}

		[HttpGet("set/{amount}")]
		public async Task<List<CleanerInfo>> GetSetCleaners (int amount,[FromQuery] string address)
		{
			return await _cleanerRepository.GetSetOfCleanersAsync(amount, address);
		}

		[HttpGet("getone")]
		public async Task<CleanerInfo> GetCleaner(string address)
		{
			return await _cleanerRepository.GetCleanerAsync(address);
		}

		[HttpGet("getone/{id}")]
		public async Task<CleanerInfo> GetCleanerById(int id)
		{
			return await _cleanerRepository.GetCleanerByIdAsync(id);
		}

		[HttpPost("add")]
		public async Task<int> AddCleaner(CleanerShortInfo cleanerInfo)
		{
			return await _cleanerRepository.AddCleanerAsync(cleanerInfo);
		}

		[HttpDelete("delete")]
		public async Task RemoveCleaner(int id)
		{
			_cleanerRepository.RemoveCleanerAsync(id);	
		}
	}
}
