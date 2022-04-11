using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotController.Data.Entities
{
    public class AreaEntity
    {
        [Key]
        public int AreaId { get; set; }
        public string? AreaName { get; set; }
        public int Area { get; set; }
    }
}
