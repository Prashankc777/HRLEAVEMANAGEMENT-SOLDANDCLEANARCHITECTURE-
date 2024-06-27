using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRLeaveManagement.Application.Feature.LeaveType.Commands.Create
{
    public class CreateLeaveTypeCommandValidator : AbstractValidator<CreateLeaveTypeCommand>
    {
        public CreateLeaveTypeCommandValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull()
                .MaximumLength(70).WithMessage(" {propertyName} must be fewer than 70 characters");

            RuleFor(p => p.DefaultDays)
                .GreaterThan(100).WithMessage("{PropertyName} cannot exceed 100 ")
                .LessThan(1).WithMessage("{PropertyName}  cannot be less than 1");

            RuleFor(q => q)
                .MustAsync(LeaveTypeNameUnique)
                .WithMessage("Leave Type already Exits");


        }

        private Task<bool> LeaveTypeNameUnique(CreateLeaveTypeCommand command, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

    }
}
