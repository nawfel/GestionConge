using Application.contracts.persistance;
using AutoMapper;
using Domain.entities;
using GestionConge.Application.Contracts.Logging;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionConge.Application.features.leaveType.queries.GetAllLeaveTypes
{
    public class GetLeaveTypesQueryHandler : IRequestHandler<GetLeaveTypeQuery, List<LeaveTypeDto>>
    {
        private readonly IMapper _mapper;
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IAppLogger<GetLeaveTypesQueryHandler> _logger;
        public GetLeaveTypesQueryHandler(IMapper mapper,ILeaveTypeRepository leaveTypeRepository, IAppLogger<GetLeaveTypesQueryHandler> logger)
        {
            _mapper= mapper;
            _leaveTypeRepository= leaveTypeRepository;
            _logger= logger;
           
        }
        public async Task<List<LeaveTypeDto>> Handle(GetLeaveTypeQuery request, CancellationToken cancellationToken)
        {
            // query the bd 
            var leaveTypes =await _leaveTypeRepository.GetAsync();
            // convert data objects to dtos 
           var data = _mapper.Map<List<LeaveTypeDto>>(leaveTypes);
            // return list of dtos 
            _logger.LogInformation("leave types where retrieved");
            return data;

        }
    }
}
