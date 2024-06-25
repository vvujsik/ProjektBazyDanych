using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HotelAssistant
{
    public class Booking
    {
        /*[Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]*/
        public Int16 BookingId { get; set; }

        public Int16 CustomerId { get; set; }

        public Int16 RoomId { get; set; }

        public DateTime RentDate { get; set; }

        public Int16 RentDuration { get; set; }

        public Int16 PersonCount { get; set; }

        public Booking(Int16 booking_id, Int16 customer_id, Int16 room_id, DateTime rent_date, Int16 rent_duration, Int16 person_count)
        {
            BookingId = booking_id;
            CustomerId = customer_id;
            RoomId = room_id;
            RentDate = rent_date;
            RentDuration = rent_duration;
            PersonCount = person_count;
        }
    }
}
