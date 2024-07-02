using Microsoft.AspNetCore.Mvc;

namespace Hr.LeaveManagement.Api.Models
{
    public class CustomProblemDetail : ProblemDetails
    {
        public IEnumerable<string> Errors { get; set; } = [];
    }
}
