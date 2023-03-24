using Application.contracts.persistance;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionConge.Application.features.leaveType.commands.updateLeaveType
{
    public class UpdateLeaveTypeCommandHandler : IRequestHandler<UpdateLeaveTypeCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly ILeaveTypeRepository _leaveRequestRepository;
        public UpdateLeaveTypeCommandHandler( IMapper mapper, ILeaveTypeRepository leaveRequestRepository)
        {
            _mapper= mapper;
            _leaveRequestRepository= leaveRequestRepository;
        }
        

        

        async Task<Unit> IRequestHandler<UpdateLeaveTypeCommand, Unit>.Handle(UpdateLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            var leaveTypeToUpdate = _mapper.Map<Domain.entities.LeaveType>(request);
            await _leaveRequestRepository.UpdateAsync(leaveTypeToUpdate);
            return Unit.Value;
           
        }
    }
}
