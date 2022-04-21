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
		public List<CleanerInfo> GetAllCleaners()
		{
			return _cleanerRepository.GetAllCleaners();
		}

		[HttpGet("allbyaddress")]
		public List<CleanerInfo> GetAllCleanersByAddress(string address)
		{
			return _cleanerRepository.GetALLCleanersByAddress(address);
		}

		[HttpGet("set/{amount}")]
		public List<CleanerInfo> GetSetCleaners (int amount,[FromQuery] string address)
		{
			return _cleanerRepository.GetSetOfCleaners(amount, address);
		}

		[HttpGet("getone")]
		public CleanerInfo GetCleaner(string address)
		{
			return _cleanerRepository.GetCleaner(address);
		}

		[HttpGet("getone/{id}")]
		public CleanerInfo GetCleanerById(int id)
		{
			return _cleanerRepository.GetCleanerById(id);
		}

		[HttpPost("add")]
		public int AddCleaner(CleanerShortInfo cleanerInfo)
		{
			return _cleanerRepository.AddCleaner(cleanerInfo);
		}

		[HttpDelete("delete")]
		public void RemoveCleaner(int id)
		{
			_cleanerRepository.RemoveCleaner(id);	
		}
	}
}
