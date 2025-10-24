using System.ComponentModel.DataAnnotations;

namespace HotelBooker.Api.Models;

public class AvailableRoomsModel : DateRangeModel
{
    [Required]
    public int[] GuestCapacity { get; set; }

    new public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        ValidateDates(validationContext);

        var today = DateOnly.FromDateTime(DateTime.UtcNow);

        if (GuestCapacity.Length > 0)
            yield return new ValidationResult("Guest Capacities are required.", new[] { nameof(GuestCapacity) });

        foreach(var capacity in GuestCapacity)
        {
            if (capacity <= 0)
                yield return new ValidationResult("Guest Capacity should not be equal or less than 1.", new[] { nameof(GuestCapacity) });
        }
    }
}
