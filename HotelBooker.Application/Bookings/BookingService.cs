using HotelBooker.Application.Bookings.Dtos;
using HotelBooker.Application.Hotels;
using HotelBooker.Application.Rooms;
using HotelBooker.Application.Rooms.Dtos;
using HotelBooker.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

    /// <summary>
    /// If I had more time on this I would look into a better way of giving a clearer result as to why the booking failed.
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    public async Task<bool> RequestBooking(BookingRequest request)
    {
        var hotelBookingRefPrefix = await _hotelRepository.GetHotelRef(request.HotelId);

        if (string.IsNullOrWhiteSpace(hotelBookingRefPrefix))
        {
            return false;
        }
        // if this is null the rooms are not available
        var availableRooms = await _roomRepository.GetSelectedAvailableRooms(new SelectedRoomsAvailability()
        {
            HotelId = request.HotelId,
            StartDate = request.StartDate,
            EndDate = request.EndDate,
            RoomIds = request.RoomsAndGuests.Select(r => r.RoomId).ToList()
        });


        if (availableRooms == null)
        {
            return false;
        }

        int nights = request.EndDate.DayNumber - request.StartDate.DayNumber;
        var totalPrice = 0.00M;
        availableRooms.ForEach(r => totalPrice = r.RoomType.PricePerNight * nights);
        var bookingId = hotelBookingRefPrefix + DateTime.UtcNow.Ticks.ToString();
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
