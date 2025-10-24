using System.ComponentModel.DataAnnotations;

namespace HotelBooker.Api.Models;

public class DateRangeModel : IValidatableObject
{
    public DateOnly StartDate { get; set; }

    public DateOnly EndDate { get; set; }
    
    protected IEnumerable<ValidationResult> ValidateDates(ValidationContext validationContext)
    {
        var today = DateOnly.FromDateTime(DateTime.UtcNow);

        if (StartDate < today)
            yield return new ValidationResult("StartDate must be today or later.", new[] { nameof(StartDate) });

        if (EndDate <= StartDate)
            yield return new ValidationResult("EndDate must be at least one day after StartDate.", new[] { nameof(EndDate) });
    }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        return ValidateDates(validationContext);
    }
}
