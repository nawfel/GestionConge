using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionConge.Application.Features.LeaveAllocation.Queries.GetLeaveAllocationsDetails
{
    public class GetLeaveAllocationDetailQuery :IRequest<LeaveAllocationDetailDto>
    {
        public int Id { get; set; }

    }
}
