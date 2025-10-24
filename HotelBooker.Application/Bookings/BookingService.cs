using HotelBooker.Application.Bookings.Dtos;
using HotelBooker.Application.Hotels;
using HotelBooker.Application.Rooms;
using HotelBooker.Domain.Entities;

namespace HotelBooker.Application.Bookings;
public class BookingService : IBookingService
{
    private readonly IBookingRepository _bookingRepository;
    private readonly IRoomRepository _roomRepository;
    private readonly IHotelRepository _hotelRepository;
    public BookingService(IBookingRepository bookingRepository,
    IRoomRepository roomRepository,
    IHotelRepository hotelRepository)
    {
        _bookingRepository = bookingRepository;
        _roomRepository = roomRepository;
        _hotelRepository = hotelRepository;
    }

    public async Task<BookingDetails> GetBookingDetails(string bookingId)
    {
        var booking = await _bookingRepository.GetBooking(bookingId);

        if (booking == null)
        {
            return null;
        }
        int nights = booking.EndDate.DayNumber - booking.StartDate.DayNumber;

        return new BookingDetails()
        {
            TotalPrice = booking.TotalPrice,
            TotalNights = nights,
            HotelName = booking.Hotel.Name,
            RoomDetails = booking.Rooms.Select(r => new BookingRoomDetails()
            {
                RoomTypeName = r.RoomType.Name,
                TotalPrice = r.RoomType.PricePerNight * nights,
                Guests = booking.Guests.Where(g => g.RoomId == r.Id).Select(g =>
                new RoomGuest()
                {
                    FirstName = g.FirstName,
                    LastName = g.LastName
                }).ToList()
            }).ToList()
        };
    }

    /// <summary>
    /// If I had more time on this I would look into a better way of giving a clearer result as to why the booking failed.
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    public async Task<string> RequestBooking(BookingRequest request)
    {
        var hotelBookingRefPrefix = await _hotelRepository.GetHotelRef(request.HotelId);

        if (string.IsNullOrWhiteSpace(hotelBookingRefPrefix))
        {
            return null;
        }
        // if this is null the rooms are not available
        var availableRooms = await _roomRepository.GetSelectedAvailableRooms(new SelectedRoomsAvailability()
        {
            HotelId = request.HotelId,
            StartDate = request.StartDate,
            EndDate = request.EndDate,
            Rooms = request.RoomsAndGuests.Select(r => new RoomAndGuestCapacity()
            {
                RoomId = r.RoomId,
                GuestCapacity = r.Guests.Count()
            }).ToList()
        });


        if (availableRooms == null)
        {
            return null;
        }

        int nights = request.EndDate.DayNumber - request.StartDate.DayNumber;
        var totalPrice = 0.00M;
        availableRooms.ForEach(r => totalPrice += r.RoomType.PricePerNight * nights);
        var bookingId = $"{hotelBookingRefPrefix}-{ DateTime.UtcNow.Ticks.ToString()}";
        var booking = new Booking()
        {
            Id = bookingId, // Theres many ways to do this.. this for now is the most unique for multiple hotels and customers in the same hotel
            HotelId = request.HotelId,
            TotalPrice = totalPrice,
            StartDate = request.StartDate,
            EndDate = request.EndDate,
            Created = DateTime.UtcNow,
            Rooms = availableRooms,
            Guests = request.RoomsAndGuests.SelectMany(r => r.Guests.Select(g =>
            new Guest()
            {
                FirstName = g.FirstName,
                LastName = g.LastName,
                RoomId = r.RoomId,
                BookingId = bookingId,
            })).ToList()
        };

        return await _bookingRepository.TryInsertBooking(booking);
    }
}
