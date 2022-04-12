using Microsoft.EntityFrameworkCore;
using RobotController.Api.Contracts;
using RobotController.Api.Helper;
using RobotController.Common;
using RobotController.Data.DataAccess;
using RobotController.Data.Entities;
using RobotController.Simulator;

namespace RobotController.Api.Services
{
    public class MovingService : IMovingService
    {
        private readonly SystemDataContext context;
        public MovingService(SystemDataContext context) {
            this.context = context;
        }
        public async Task<string> Move(MovingCommandContract movingContract)
        {
            try
            {
                var maxNumberOfStep = await CheckOfficeArea();
                CommandFactory commandFactory = new CommandFactory();
                var command = commandFactory.CreateCommand(movingContract, maxNumberOfStep);
                CleaningReport reporter = new CleaningReport();
                var startDate = DateTime.Now;
                Robot robot = new Robot(command, reporter, new Location(0, 0), new Location(7, 7));
                robot.ExecuteCommands();
                var duration = DateTime.Now - startDate;

                await SaveRessultAsync(movingContract.Commmands.Count(), robot.PrintReport(), duration);
                return "Cleaning Report " + robot.PrintReport();

            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }


        private async Task<int> CheckOfficeArea()
        {
            var area = await context.Area.FirstOrDefaultAsync();
            var maxNumberOfStep = (area != null)? area.Area : 200;
            return maxNumberOfStep;
        }


        private async Task SaveRessultAsync(int commandsCount, int resultCount, TimeSpan duration)
        {
            try
            {
                var result = await context.Reports.AddAsync(new ReportEntity()
                {
                    Commands = commandsCount,
                    Duration = duration,
                    Result = resultCount,
                    Timestamp = DateTime.Now
                });

                this.context.SaveChanges();

            }
            catch (Exception ex)
            {

                throw;
            }
        }

    }
}
