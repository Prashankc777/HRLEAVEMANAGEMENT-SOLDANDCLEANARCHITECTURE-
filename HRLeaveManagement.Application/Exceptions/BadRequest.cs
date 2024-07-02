using FluentValidation.Results;

namespace HRLeaveManagement.Application.Exceptions;

public class BadRequestException : Exception
{
    public BadRequestException(string message) : base(message)
    {
            
    }
    public BadRequestException(string message, ValidationResult validationResult) : base(message)
    {
        ValidationErrors = validationResult.Errors.Select(e => e.ErrorMessage);
    }

    public IEnumerable<string> ValidationErrors { get; set; }
}