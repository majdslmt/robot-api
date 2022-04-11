using RobotController.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotController.Simulator
{
    public class Robot
    {
        public Location Position { get; set; }
        private CommandString _commandSet;
        private readonly IReport _reporter;
        private readonly Location _bottomLeftBound;
        private readonly Location _topRightBound;


        public Robot(CommandString commandSet, IReport reporter) : this(commandSet, reporter, null, null)
        {
        }


        public Robot(CommandString commandSet, IReport reporter, Location bottomLeftBound, Location topRightBound)
        {
            _commandSet = commandSet;
            _reporter = reporter;
            _bottomLeftBound = bottomLeftBound;
            _topRightBound = topRightBound;
            Position = _commandSet.StartPosition;
        }

        public void ExecuteCommands()
        {
            foreach (MovementCommand move in _commandSet.MovementCommands)
            {
                for (int i = 0; i < move.MoveSteps; i++)
                {
                    MoveRobot(move);
                    Thread.Sleep(2000);
                }
            }
        }

        private void MoveRobot(MovementCommand move)
        {
            switch (move.MoveDirection)
            {
                case Direction.North:
                    Position = new Location(Position.X, Position.Y + 1);
                    break;
                case Direction.East:
                    Position = new Location(Position.X + 1, Position.Y);
                    break;
                case Direction.South:
                    Position = new Location(Position.X, Position.Y - 1);
                    break;
                case Direction.West:
                    Position = new Location(Position.X - 1, Position.Y);
                    break;
            }

            if (_reporter != null) _reporter.RegisterNewPosition(Position);

        }


        public int PrintReport()
        {
            if (_reporter == null)
                return 0;

            return _reporter.PrintReport();
        }

    }
}
