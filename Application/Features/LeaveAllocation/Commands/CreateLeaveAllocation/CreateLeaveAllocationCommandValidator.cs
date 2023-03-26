using Application.contracts.persistance;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionConge.Application.Features.LeaveAllocation.Commands.CreateLeaveAllocation
{
    public class CreateLeaveAllocationCommandValidator : AbstractValidator<CreateLeaveAllocationCommand>
    {
        private readonly ILeaveTypeRepository leaveTypeRepository;

        public CreateLeaveAllocationCommandValidator(ILeaveTypeRepository leaveTypeRepository)
        {
            this.leaveTypeRepository = leaveTypeRepository;
            RuleFor(p => p.LeaveTypeId).GreaterThan(0).MustAsync(LeaveTypeMustAsync).WithMessage("{PropertyName} does not exist");
        }

        private async Task<bool> LeaveTypeMustAsync(int id, CancellationToken arg2)
        {
            var leaveType = await leaveTypeRepository.GetByIdAsync(id);
            return leaveType != null;
        }
    }
}
