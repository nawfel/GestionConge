using Application.contracts.persistance;
using AutoMapper;
using MediatR;


namespace GestionConge.Application.Features.LeaveAllocation.Queries.GetLeaveAllocations;

public class GetLeaveAllocationListHandler : IRequestHandler<GetLeaveAllocationListQuery, List<LeaveAllocationDto>>
{
    private readonly ILeaveAllocationRepository leaveAllocationRepository;
    private readonly IMapper mapper;

    public GetLeaveAllocationListHandler(ILeaveAllocationRepository leaveAllocationRepository,IMapper mapper)
    {
        this.leaveAllocationRepository = leaveAllocationRepository;
        this.mapper = mapper;
    }
    async Task<List<LeaveAllocationDto>> IRequestHandler<GetLeaveAllocationListQuery, List<LeaveAllocationDto>>.Handle(GetLeaveAllocationListQuery request, CancellationToken cancellationToken)
    {
        var leaveAllocations = await leaveAllocationRepository.GetLeaveAllocationsWithDetails();
        var allocations = mapper.Map<List<LeaveAllocationDto>>(leaveAllocations);
        return allocations;
    }
}
