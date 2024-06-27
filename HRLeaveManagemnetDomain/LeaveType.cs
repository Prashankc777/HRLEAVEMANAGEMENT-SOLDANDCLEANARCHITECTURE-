﻿using HRLeaveManagemnetDomain.Common;

namespace HRLeaveManagemnetDomain;

public class LeaveType : BaseEntity
{
   
    public string Name { get; set; } = string.Empty;
    public int DefaultDays { get; set; }
}