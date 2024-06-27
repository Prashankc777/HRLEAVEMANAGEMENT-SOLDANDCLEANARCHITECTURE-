using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using HRLeaveManagement.Application.Contracts.Persistence;
using HRLeaveManagement.Application.Exceptions;
using MediatR;

namespace HRLeaveManagement.Application.Feature.LeaveType.Commands.Create
{
    public class CreateLeaveTypeCommandHandler : IRequestHandler<CreateLeaveTypeCommand , int>
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
            var validator = new CreateLeaveTypeCommandValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);
            if (validationResult.Errors.Any())
            {
                throw new BadRequestException("Invalid Leave Type", validationResult);
            }
            var leaveTypeToCreate = _mapper.Map<HRLeaveManagemnetDomain.LeaveType>(request);
            await _leaveTypeRepository.CreateAsync(leaveTypeToCreate);
            return leaveTypeToCreate.Id;
        }
    }
}
