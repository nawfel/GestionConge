using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionConge.Application.features.leaveType.queries.GetLeaveTypeDetails
{
    public record GetLeaveTypeDetailsQuery(int Id) : IRequest<LeaveTypeDetailsDto>;

}
