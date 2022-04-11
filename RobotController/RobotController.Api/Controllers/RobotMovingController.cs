using Microsoft.AspNetCore.Mvc;
using RobotController.Api.Contracts;
using RobotController.Api.Services;

namespace RobotController.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RobotMovingController : ControllerBase
    {

        private readonly ILogger<RobotMovingController> _logger;
        private readonly IMovingService movingService;

        public RobotMovingController(ILogger<RobotMovingController> logger, IMovingService movingService)
        {
            _logger = logger;
            this.movingService = movingService;
        }

        [HttpPost(Name = "SendRequest")]
        public async Task<IActionResult> SendRequest(MovingCommandContract movingCommandContract)
        {

            var x = await movingService.Move(movingCommandContract);

            return Ok();
        }
    }
}