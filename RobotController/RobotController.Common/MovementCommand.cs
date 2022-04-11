using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotController.Common
{
    public class MovementCommand
    {
        public Direction MoveDirection { get; set; }
        public int MoveSteps { get; set; }
    }
}
