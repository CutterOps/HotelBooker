using System.ComponentModel.DataAnnotations;

namespace HotelBooker.Application.Bookings.Dtos;
public class DateRangeDto : IValidatableObject
{
    /// <summary>
    /// Due to the nature of this challenge. I would have sat and designed this a bit better
    /// I could think about checkout times etc.
    /// </summary>
    public DateOnly StartDate { get; set; }

    public DateOnly EndDate { get; set; }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        var today = DateOnly.FromDateTime(DateTime.UtcNow);

        if (StartDate < today)
            yield return new ValidationResult("StartDate must be today or later.", new[] { nameof(StartDate) });

        if (EndDate <= StartDate)
            yield return new ValidationResult("EndDate must be at least one day after StartDate.", new[] { nameof(EndDate) });
    }
}
