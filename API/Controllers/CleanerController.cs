using Core.CleanerNotificationService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CleanerController : ControllerBase
	{
		private readonly ICleanerNotificationService _cleanerNotification;
		public CleanerController(ICleanerNotificationService cleanerNotification)
		{
			_cleanerNotification = cleanerNotification;
		}

		[HttpPost("update")]
		public async Task CleanerIsComing(CleanerNotificationInfo cleanerInfo)
		{
			await _cleanerNotification.UpdateCleanerConditionAsync(cleanerInfo);
		}
	}
}
