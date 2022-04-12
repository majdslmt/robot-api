using RobotController.Common;
using RobotController.Simulator;

namespace RobotController.Api
{
    public class CleaningReport : IReport
    {
        private SortedSet<Location> _cleanedLocationStrings;

        public CleaningReport()
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
