using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooker.Application.Bookings.Dtos;
public class BookingResult
{
    public Guid HotelId { get; set; }

    public string BookingRef { get; set; }

    public decimal TotalPrice { get; set; }
}
