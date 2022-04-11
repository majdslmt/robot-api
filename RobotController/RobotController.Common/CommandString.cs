using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotController.Common
{
    public class CommandString
    {
        public int NumberOfCommands
        {
            get { return _numberOfCommands; }
            set { _numberOfCommands = value; }
        }
        private int _numberOfCommands;

        public Location StartPosition
        {
            get { return _startPosition; }
            set { _startPosition = value; }
        }

        private Location _startPosition;

        public List<MovementCommand> MovementCommands
        {
            get { return _movementCommands; }
        }
        private List<MovementCommand> _movementCommands;

        public CommandString()
        {
            _movementCommands = new List<MovementCommand>();
        }

    }
}
