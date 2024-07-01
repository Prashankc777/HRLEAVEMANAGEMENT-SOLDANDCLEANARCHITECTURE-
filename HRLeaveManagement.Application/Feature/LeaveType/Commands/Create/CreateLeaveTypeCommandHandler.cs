using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using HRLeaveManagement.Application.Contracts.Logging;
using HRLeaveManagement.Application.Contracts.Persistence;
using HRLeaveManagement.Application.Exceptions;
using MediatR;

namespace HRLeaveManagement.Application.Feature.LeaveType.Commands.Create
{
    public class CreateLeaveTypeCommandHandler : IRequestHandler<CreateLeaveTypeCommand , int>
    {
        private readonly IMapper _mapper;
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IAppLogger<CreateLeaveTypeCommandHandler> _appLogger;

        public CreateLeaveTypeCommandHandler(IMapper mapper, ILeaveTypeRepository leaveTypeRepository, IAppLogger<CreateLeaveTypeCommandHandler> appLogger)
        {
            _mapper = mapper;
            _leaveTypeRepository = leaveTypeRepository;
            _appLogger = appLogger;
        }
        public async Task<int> Handle(CreateLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateLeaveTypeCommandValidator(_leaveTypeRepository);
            var validationResult = await validator.ValidateAsync(request, cancellationToken);
            if (validationResult.Errors.Any())
            {
                _appLogger.LogWarning("Validation errors in update request", nameof(HRLeaveManagemnetDomain.LeaveType), request);
                throw new BadRequestException("Invalid Leave Type", validationResult);
            }
            var leaveTypeToCreate = _mapper.Map<HRLeaveManagemnetDomain.LeaveType>(request);
            await _leaveTypeRepository.CreateAsync(leaveTypeToCreate);
            return leaveTypeToCreate.Id;
        }
    }
}
