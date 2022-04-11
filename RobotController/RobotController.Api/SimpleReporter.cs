using RobotController.Common;
using RobotController.Simulator;

namespace RobotController.Api
{
    public class SimpleReporter : IReport
    {
        private SortedSet<Location> _cleanedLocationStrings;

        public SimpleReporter()
        {
            _cleanedLocationStrings = new SortedSet<Location>();
        }

        public int PrintReport()
        {
            return  _cleanedLocationStrings.Count;
        }


        public void RegisterNewPosition(Location position)
        {
            _cleanedLocationStrings.Add(position);
        }

    }
}
