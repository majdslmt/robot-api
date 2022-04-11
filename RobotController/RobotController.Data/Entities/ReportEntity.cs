using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotController.Data.Entities
{
    public class ReportEntity
    {
        public Guid Id { get; set; }
        public DateTime Timestamp { get; set; }
        public int Commands { get; set; }
        public int Result { get; set; }
        public TimeSpan Duration { get; set; }
    }
}
