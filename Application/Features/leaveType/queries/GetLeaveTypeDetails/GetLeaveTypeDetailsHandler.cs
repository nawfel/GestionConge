using Application.contracts.persistance;
using AutoMapper;
using GestionConge.Application.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionConge.Application.features.leaveType.queries.GetLeaveTypeDetails
{
    public class GetLeaveTypeDetailsHandler : IRequestHandler<GetLeaveTypeDetailsQuery, LeaveTypeDetailsDto>
    {
        private readonly IMapper _mapper;
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        public GetLeaveTypeDetailsHandler(IMapper mapper, ILeaveTypeRepository leaveTypeRepository)
        {
            _mapper = mapper;
            _leaveTypeRepository = leaveTypeRepository;
        }
        public async Task<LeaveTypeDetailsDto> Handle(GetLeaveTypeDetailsQuery request, CancellationToken cancellationToken)
        {
            // query the db 
            var leaveTypes = await _leaveTypeRepository.GetByIdAsync(request.Id);
            if(leaveTypes == null ) throw new NotFoundException(nameof(leaveTypes),request.Id);
            // map the objects 
            var data = _mapper.Map<LeaveTypeDetailsDto>(leaveTypes);
            // return the data
            return data;
        }
    }
}
