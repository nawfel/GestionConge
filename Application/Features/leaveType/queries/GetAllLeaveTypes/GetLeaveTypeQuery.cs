using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionConge.Application.features.leaveType.queries.GetAllLeaveTypes
{
    public record GetLeaveTypeQuery : IRequest<List<LeaveTypeDto>>;
 
}
