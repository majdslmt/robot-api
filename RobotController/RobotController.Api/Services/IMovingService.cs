using RobotController.Api.Contracts;

namespace RobotController.Api.Services
{
    public interface IMovingService
    {
        Task<bool> Move(MovingCommandContract movingContract);
    }
}
