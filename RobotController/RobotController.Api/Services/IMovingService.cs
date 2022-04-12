using RobotController.Api.Contracts;

namespace RobotController.Api.Services
{
    public interface IMovingService
    {
        Task<string> Move(MovingCommandContract movingContract);
    }
}
