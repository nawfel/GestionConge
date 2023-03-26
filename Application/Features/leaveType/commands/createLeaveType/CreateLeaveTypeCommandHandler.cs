using Application.contracts.persistance;
using AutoMapper;
using Domain.entities;
using GestionConge.Application.Exceptions;
using GestionConge.Application.Features.leaveType.commands.createLeaveType;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionConge.Application.features.leaveType.commands.createLeaveType
{
    public class CreateLeaveTypeCommandHandler : IRequestHandler<CreateLeaveTypeCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        public CreateLeaveTypeCommandHandler(IMapper mapper, ILeaveTypeRepository leaveTypeRepository)
        {

            _mapper = mapper;
            _leaveTypeRepository = leaveTypeRepository;
        }
        public async Task<int> Handle(CreateLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            // validate incoming data;
            var validator = new CreateLeaveTypeCommandValidator(_leaveTypeRepository);
            var validationResult = await validator.ValidateAsync(request);
            if (!validationResult.Errors.Any()) throw new BadRequestException("invalid leavetype",validationResult);
            // convert to domain entity object ;
            var leaveTypeToCreate = _mapper.Map<LeaveType>(request);
            // add to db
            await _leaveTypeRepository.CreateAsync(leaveTypeToCreate);

            // return record Id
            return leaveTypeToCreate.Id;
        }
    }
}
