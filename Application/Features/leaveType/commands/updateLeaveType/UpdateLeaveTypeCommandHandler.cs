using Application.contracts.persistance;
using AutoMapper;
using Domain.entities;
using GestionConge.Application.Contracts.Logging;
using GestionConge.Application.Exceptions;
using HR.LeaveManagement.Application.Features.LeaveType.Commands.UpdateLeaveType;
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
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IAppLogger<UpdateLeaveTypeCommandHandler> _logger;
        public UpdateLeaveTypeCommandHandler( IMapper mapper, ILeaveTypeRepository leaveRequestRepository, IAppLogger<UpdateLeaveTypeCommandHandler> logger)
        {
            _logger = logger;
            _mapper= mapper;
            _leaveTypeRepository = leaveRequestRepository;
        }
        

        

        async Task<Unit> IRequestHandler<UpdateLeaveTypeCommand, Unit>.Handle(UpdateLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateLeaveTypeCommandValidator(_leaveTypeRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Any())
            {
                _logger.LogWarning("Validation errors in update request for {0} - {1}", nameof(LeaveType), request.Id);
                throw new BadRequestException("Invalid Leave type", validationResult);
            }
            var leaveTypeToUpdate = _mapper.Map<LeaveType>(request);
            await _leaveTypeRepository.UpdateAsync(leaveTypeToUpdate);
            return Unit.Value;
           
        }
    }
}
