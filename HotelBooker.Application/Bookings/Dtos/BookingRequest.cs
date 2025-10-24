using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooker.Application.Bookings.Dtos;
public class BookingRequest : DateRangeDto
{
    public Guid HotelId { get; set; }
    public List<RoomAndGuests> RoomsAndGuests { get; set; }

}
