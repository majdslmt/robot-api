using RobotController.Data.DataAccess;
using RobotController.Data.Entities;

namespace RobotController.Api
{
    public static class DataSeeder
    {
        public static void Seed(this IHost host)
        {
            using var scope = host.Services.CreateScope();
            using var context = scope.ServiceProvider.GetRequiredService<SystemDataContext>();
            context.Database.EnsureCreated();
            AddArea(context);
        }

        private static void AddArea(SystemDataContext context)
        {
            var area = context.Area.FirstOrDefault();
            if (area != null) return;

            context.Area.Add(new AreaEntity
            {
                AreaId = 1,
                Area = 200,
                AreaName = "office"
            });
            context.SaveChanges();

        }
    }
}
