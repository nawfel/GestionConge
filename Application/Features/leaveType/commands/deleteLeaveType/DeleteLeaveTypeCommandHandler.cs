using Application.contracts.persistance;
using AutoMapper;
using GestionConge.Application.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionConge.Application.features.leaveType.commands.deleteLeaveType
{
    public class DeleteLeaveTypeCommandHandler : IRequestHandler<DeleteLeaveTypeCommand, Unit>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        public DeleteLeaveTypeCommandHandler(IMapper mapper, ILeaveTypeRepository leaveTypeRepository)
        {
            _leaveTypeRepository = leaveTypeRepository;
        }
        public async Task<Unit> Handle(DeleteLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            var leaveTypeToDelete = await _leaveTypeRepository.GetByIdAsync(request.Id);
            if (leaveTypeToDelete == null)
                throw new NotFoundException(nameof(leaveType), request.Id);

            await _leaveTypeRepository.DeleteAsync(leaveTypeToDelete);

            return Unit.Value;
        }
    }
}
