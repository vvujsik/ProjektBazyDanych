using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelApp
{
    public enum RoomType : Int16 { SMALL, MEDIUM, BIG, VIP, DISABLED }
    internal class room
    {
        public int roomId { get; set; }
        public int hotelId { get; set; }
        public RoomType roomType { get; set; }
        public int floor {  get; set; }
        public int maxCapacity { get; set; }

        public override string ToString()
        {
            String wynik = "";
            wynik += "Room ID: " + roomId + " | Hotel ID: " + hotelId + " | room Type: " + roomType + " | Floor: " + floor + " | Pojemnosc: " + maxCapacity;
            return wynik;
        }
    }
}