using RobotController.Api.Contracts;
using RobotController.Common;

namespace RobotController.Api.Helper
{
    public class CommandFactory
    {


        internal readonly CommandString command;

        public CommandFactory()
        {
            command = new CommandString();
        }
        public CommandString CreateCommand(MovingCommandContract movingCommandContract, int maxNumberOfStep)
        {
            command.StartPosition = new Location(movingCommandContract.Start.x, movingCommandContract.Start.y);
            foreach (var item in movingCommandContract.Commmands)
            {
                if (CheckNumberOfStep(item.Steps, maxNumberOfStep))
                {
                    command.MovementCommands.Add(new MovementCommand()
                    {
                        MoveSteps = item.Steps,
                        MoveDirection = GetDirection(item.Direction)
                    });

                }
            }
            return command;
        }

        private Direction GetDirection(string inputDirection)
        {
            switch (inputDirection.ToUpper())
            {
                case "N":
                    return Direction.North;
                case "S":   
                    return Direction.South;
                case "E":
                    return Direction.East;
                case "W":
                    return Direction.West;
                default:
                    return Direction.Unknown;
            }
        }


        private bool CheckNumberOfStep(int steps, int maxNumberOfStep)
        {
            if (Enumerable.Range(0, maxNumberOfStep).Contains(steps))
                return true;
            else
                return false;
        }

    }
}
