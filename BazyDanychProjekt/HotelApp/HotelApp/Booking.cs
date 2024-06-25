using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelApp
{
    internal class Booking
    {
        public int bookingId { get; set; }
        public int customerId { get; set; }
        public int roomId { get; set; }
        public DateTime rentDate { get; set; }
        public int rentDuration { get; set; }
        public int personCount { get; set; }

        public override string ToString()
        {
            return "BookingId: " + this.bookingId + "   RoomId: " + this.roomId + "   RentDate: " + this.rentDate.ToString();
        }
    }
}
