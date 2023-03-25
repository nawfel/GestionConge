using Application.contracts.persistance;
using FluentValidation;
using GestionConge.Application.features.leaveType.commands.createLeaveType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionConge.Application.Features.leaveType.commands.createLeaveType
{
    public class CreateLeaveTypeCommandValidator : AbstractValidator<CreateLeaveTypeCommand>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        public CreateLeaveTypeCommandValidator(ILeaveTypeRepository leaveTypeRepository)
        {
            RuleFor(p => p.Name).NotEmpty().WithMessage("{PropertyName} is required").NotNull().MaximumLength(70).WithMessage("{PropertyName} must be fewer than 70");
            RuleFor(p => p.DefaultDays).LessThan(100).WithMessage("{PropertyName} can not exceed 100").GreaterThan(1).WithMessage("{PropertyName} can not be less than 1");
            RuleFor(p => p).MustAsync(LeaveTypeNameUnique).WithMessage("leave type already exists");
            _leaveTypeRepository = leaveTypeRepository;
        }

        private Task<bool> LeaveTypeNameUnique(CreateLeaveTypeCommand command, CancellationToken token)
        {
            return _leaveTypeRepository.IsLeaveTypeUnique(command.Name);
        }
    }
}
