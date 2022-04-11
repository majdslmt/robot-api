using Microsoft.EntityFrameworkCore;
using RobotController.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotController.Data.DataAccess
{
    public class SystemDataContext : DbContext
    {
        public SystemDataContext(DbContextOptions<SystemDataContext> options) :
    base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseSerialColumns();
        }

        public DbSet<AreaEntity> Area { get; set; }
        public DbSet<ReportEntity> Reports { get; set; }

    }
}
