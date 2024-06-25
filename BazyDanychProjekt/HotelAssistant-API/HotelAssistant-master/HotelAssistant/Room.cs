using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HotelAssistant
{
    public enum RoomType : short
    {
        SMALL,
        MEDIUM,
        BIG,
        VIP,
        DIS
    }

    public class Room
    {
        /*[Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]*/
        public Int16 RoomId { get; set; }

        public Int16 HotelId { get; set; }

        public RoomType RoomType { get; set; }

        public Int16 Floor { get; set; }

        public Int16 MaxCapacity { get; set; }

        public Room(Int16 room_id, Int16 hotel_id, RoomType room_type, Int16 floor, Int16 max_capacity)
        {
            RoomId = room_id;
            HotelId = hotel_id;
            RoomType = room_type;
            Floor = floor;
            MaxCapacity = max_capacity;
        }
    }
}
