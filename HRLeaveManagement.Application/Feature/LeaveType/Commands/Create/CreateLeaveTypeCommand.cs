﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace HRLeaveManagement.Application.Feature.LeaveType.Commands.Create
{
    public class CreateLeaveTypeCommand : IRequest<int>
    {
        public string Name { get; set; } = string.Empty; 
        public int DefaultDays { get; set; }


    }
}