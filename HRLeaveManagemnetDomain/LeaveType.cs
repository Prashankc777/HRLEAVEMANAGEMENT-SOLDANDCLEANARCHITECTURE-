using System.ComponentModel.DataAnnotations;
using HRLeaveManagemnetDomain.Common;

namespace HRLeaveManagemnetDomain;

public class LeaveType : BaseEntity
{

    [StringLength(50)]
    public string Name { get; set; } = string.Empty;
    public int DefaultDays { get; set; }
}