using Application.contracts.persistance;
using AutoMapper;
using Domain.entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionConge.Application.features.leaveType.queries.GetAllLeaveTypes
{
    public class GetLeaveTypesHandler : IRequestHandler<GetLeaveTypeQuery, List<LeaveTypeDto>>
    {
        private readonly IMapper _mapper;
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        public GetLeaveTypesHandler(IMapper mapper,ILeaveTypeRepository leaveTypeRepository)
        {
            _mapper= mapper;
            _leaveTypeRepository= leaveTypeRepository; 
        }
        public async Task<List<LeaveTypeDto>> Handle(GetLeaveTypeQuery request, CancellationToken cancellationToken)
        {
            // query the bd 
            var leaveTypes =await _leaveTypeRepository.GetAsync();
            // convert data objects to dtos 
           var data = _mapper.Map<List<LeaveTypeDto>>(leaveTypes);
            // return list of dtos 
            return data;

        }
    }
}
