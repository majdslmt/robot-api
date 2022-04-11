using RobotController.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotController.Simulator
{
    public interface IReport
    {
        int PrintReport();

        void RegisterNewPosition(Location position);

    }
}
