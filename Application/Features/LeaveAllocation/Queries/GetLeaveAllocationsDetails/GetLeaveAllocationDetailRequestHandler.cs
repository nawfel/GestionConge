using Application.contracts.persistance;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionConge.Application.Features.LeaveAllocation.Queries.GetLeaveAllocationsDetails
{
    public class GetLeaveAllocationDetailRequestHandler : IRequestHandler<GetLeaveAllocationDetailQuery, LeaveAllocationDetailDto>
    {
        private readonly ILeaveAllocationRepository leaveAllocationRepository;
        private readonly IMapper mapper;

        public GetLeaveAllocationDetailRequestHandler(ILeaveAllocationRepository leaveAllocationRepository, IMapper mapper)
        {
            this.leaveAllocationRepository = leaveAllocationRepository;
            this.mapper = mapper;
        }
        public async Task<LeaveAllocationDetailDto> Handle(GetLeaveAllocationDetailQuery request, CancellationToken cancellationToken)
        {
            var leaveAllocations = await leaveAllocationRepository.GetLeaveAllocationWithDetails(request.Id);
            return mapper.Map<LeaveAllocationDetailDto>(leaveAllocations);

        }
    }
}
