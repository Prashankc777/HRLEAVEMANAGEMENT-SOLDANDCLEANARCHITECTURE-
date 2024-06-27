using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRLeaveManagemnetDomain;
using Microsoft.EntityFrameworkCore;

namespace HRLeaveManagement.Persisrtance.LeaveTypeConfiguration
{
    public class LeaveTypeConfiguration : IEntityTypeConfiguration<LeaveType>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<LeaveType> builder)
        {
            builder.HasData(
            new LeaveType()
            {
                Id = 1,
                Name = "Vacation",
                DefaultDays = 7,
                DateCreated = DateTime.Now,
                DateModifiedDate = DateTime.Now
            });

            builder.Property(q => q.Name)
                .IsRequired()
                .HasMaxLength(100);
        }
    }


}
