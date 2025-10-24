using HotelBooker.Application.Bookings.Dtos;
using System.ComponentModel.DataAnnotations;

namespace HotelBooker.Api.Models;

public class BookingModel : DateRangeModel
{
    public List<RoomAndGuests> RoomAndGuests { get; set; }

    new public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        ValidateDates(validationContext);

        var today = DateOnly.FromDateTime(DateTime.UtcNow);

        if (RoomAndGuests.Count > 0)
            yield return new ValidationResult("Rooms are Required.", new[] { nameof(RoomAndGuests) });

        foreach (var room in RoomAndGuests)
        {
            if (room.Guests == null || room.Guests.Count == 0)
                yield return new ValidationResult("Guest Capacity should not be equal or less than 1.", new[] { nameof(RoomAndGuests) });
        }

        var duplicateRoomIds = RoomAndGuests
            .GroupBy(rg => rg.RoomId)
            .Where(g => g.Count() > 1)
            .Select(g => g.Key)
            .ToList();

        if (duplicateRoomIds.Count > 0)
        {
            yield return new ValidationResult("The same room cannot be used twice in the same booking.", new[] { nameof(RoomAndGuests) });
        }
    }
}
