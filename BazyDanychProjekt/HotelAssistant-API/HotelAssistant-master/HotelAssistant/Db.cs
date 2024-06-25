using Npgsql;

namespace HotelAssistant
{
    public class Db
    {
        static public string masterConnectionString = "Server=localhost;Port=5431;Username=postgres;Password=password;Database=hotel;";
        static public string slaveConnectionString = "Server=localhost;Port=5433;Username=postgres;Password=password;Database=hotel;";
    }
}
