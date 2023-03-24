using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionConge.Application.features.leaveType.queries.GetAllLeaveTypes
{
    public class LeaveTypeDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int DefaultDays { get; set; }
    }
}
