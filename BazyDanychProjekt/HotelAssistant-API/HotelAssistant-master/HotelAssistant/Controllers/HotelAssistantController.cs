using Microsoft.AspNetCore.Mvc;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace HotelAssistant.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HotelAssistantController : ControllerBase
    {
        public HotelAssistantController()
        {
        }

        [HttpPost("AddCustomer")]
        public async Task<int> AddCustomer(string firstName, string lastName, int phoneNumber, string email)
        {
            using var connection = new NpgsqlConnection(Db.masterConnectionString);
            await connection.OpenAsync();
            using var transaction = await connection.BeginTransactionAsync();

            try
            {
                using var cmd = new NpgsqlCommand
                {
                    Connection = connection,
                    Transaction = transaction,
                    CommandText = "INSERT INTO customer (first_name, last_name, phone_number, email) VALUES (@FirstName, @LastName, @PhoneNumber, @Email);"
                };
                cmd.Parameters.AddWithValue("FirstName", firstName);
                cmd.Parameters.AddWithValue("LastName", lastName);
                cmd.Parameters.AddWithValue("PhoneNumber", phoneNumber);
                cmd.Parameters.AddWithValue("Email", email);

                var result = await cmd.ExecuteNonQueryAsync();
                await transaction.CommitAsync();
                return result;
            }
            catch (Exception)
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        [HttpGet("GetCustomerIdByPhone")]
        public async Task<short> GetCustomerId(int phoneNumber)
        {
            using var connection = new NpgsqlConnection(Db.slaveConnectionString);
            await connection.OpenAsync();

            using var cmd = new NpgsqlCommand
            {
                Connection = connection,
                CommandText = "SELECT customer_id FROM customer WHERE phone_number = @PhoneNumber;"
            };
            cmd.Parameters.AddWithValue("PhoneNumber", phoneNumber);

            using var reader = await cmd.ExecuteReaderAsync();
            return await reader.ReadAsync() ? reader.GetInt16(0) : (short)-1;
        }

        [HttpGet("GetCustomerIdByEmail")]
        public async Task<short> GetCustomerId(string email)
        {
            using var connection = new NpgsqlConnection(Db.slaveConnectionString);
            await connection.OpenAsync();

            using var cmd = new NpgsqlCommand
            {
                Connection = connection,
                CommandText = "SELECT customer_id FROM customer WHERE email = @Email;"
            };
            cmd.Parameters.AddWithValue("Email", email);

            using var reader = await cmd.ExecuteReaderAsync();
            return await reader.ReadAsync() ? reader.GetInt16(0) : (short)-1;
        }

        [HttpPost("AddBooking")]
        public async Task<int> AddBooking(short customerId, short roomId, DateTime rentDate, short rentDuration, short personCount)
        {
            using var connection = new NpgsqlConnection(Db.masterConnectionString);
            await connection.OpenAsync();
            using var transaction = await connection.BeginTransactionAsync();

            try
            {
                using var cmd = new NpgsqlCommand
                {
                    Connection = connection,
                    Transaction = transaction,
                    CommandText = "INSERT INTO booking (customer_id, room_id, rent_date, rent_duration, person_count) VALUES (@CustomerId, @RoomId, @RentDate, @RentDuration, @PersonCount);"
                };
                cmd.Parameters.AddWithValue("CustomerId", customerId);
                cmd.Parameters.AddWithValue("RoomId", roomId);
                cmd.Parameters.AddWithValue("RentDate", rentDate);
                cmd.Parameters.AddWithValue("RentDuration", rentDuration);
                cmd.Parameters.AddWithValue("PersonCount", personCount);

                var result = await cmd.ExecuteNonQueryAsync();
                await transaction.CommitAsync();
                return result;
            }
            catch (Exception)
            {
                await transaction.RollbackAsync();
                throw;
            }
        }


        [HttpGet("FindNextBookingId")]
        public async Task<short> FindNextBookingId(DateTime date)
        {
            using var connection = new NpgsqlConnection(Db.slaveConnectionString);
            await connection.OpenAsync();

            using var cmd = new NpgsqlCommand
            {
                Connection = connection,
                CommandText = "SELECT booking_id FROM booking WHERE rent_date > @Date ORDER BY rent_date ASC;"
            };
            cmd.Parameters.AddWithValue("Date", date);

            using var reader = await cmd.ExecuteReaderAsync();
            return await reader.ReadAsync() ? reader.GetInt16(0) : (short)-1;
        }

        [HttpDelete("RemoveBooking")]
        public async Task<int> RemoveBooking(short bookingId)
        {
            using var connection = new NpgsqlConnection(Db.masterConnectionString);
            await connection.OpenAsync();
            using var transaction = await connection.BeginTransactionAsync();

            try
            {
                using var cmd = new NpgsqlCommand
                {
                    Connection = connection,
                    Transaction = transaction,
                    CommandText = "DELETE FROM booking WHERE booking_id = @BookingId;"
                };
                cmd.Parameters.AddWithValue("BookingId", bookingId);

                var result = await cmd.ExecuteNonQueryAsync();
                await transaction.CommitAsync();
                return result;
            }
            catch (Exception)
            {
                await transaction.RollbackAsync();
                throw;
            }
        }


        [HttpGet("GetBookings")]
        public async Task<IEnumerable<Booking>> GetBookings()
        {
            var result = new List<Booking>();
            using var connection = new NpgsqlConnection(Db.slaveConnectionString);
            await connection.OpenAsync();

            using var cmd = new NpgsqlCommand
            {
                Connection = connection,
                CommandText = "SELECT * FROM booking;"
            };

            using var reader = await cmd.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                result.Add(new Booking(
                    booking_id: reader.GetInt16(0),
                    customer_id: reader.GetInt16(1),
                    room_id: reader.GetInt16(2),
                    rent_date: reader.GetDateTime(3),
                    rent_duration: reader.GetInt16(4),
                    person_count: reader.GetInt16(5)));
            }
            return result;
        }

        [HttpGet("GetFreeRoomsByCapacityDesc")]
        public async Task<IEnumerable<Room>> GetFreeRoomsFilterRoomMaxCapacityDescending(DateTime rentStartDate, DateTime rentEndDate)
        {
            var result = new List<Room>();
            using var connection = new NpgsqlConnection(Db.slaveConnectionString);
            await connection.OpenAsync();

            using var cmd = new NpgsqlCommand
            {
                Connection = connection,
                CommandText = @"
            SELECT * FROM room
            WHERE room_id NOT IN (
                SELECT room_id 
                FROM booking 
                WHERE rent_date <= @RentEndDate 
                AND (rent_date + (rent_duration * INTERVAL '1 day')) >= @RentStartDate
            )
            ORDER BY max_capacity DESC;"
            };
            cmd.Parameters.AddWithValue("RentStartDate", rentStartDate);
            cmd.Parameters.AddWithValue("RentEndDate", rentEndDate);

            using var reader = await cmd.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                result.Add(new Room(
                    room_id: reader.GetInt16(0),
                    hotel_id: reader.GetInt16(1),
                    room_type: Enum.Parse<RoomType>(reader.GetString("room_type")),
                    floor: reader.GetInt16(3),
                    max_capacity: reader.GetInt16(4)));
            }
            return result;
        }


        [HttpGet("GetFreeRoomsByCapacityAsc")]
        public async Task<IEnumerable<Room>> GetFreeRoomsFilterRoomMaxCapacityAscending(DateTime rentStartDate, DateTime rentEndDate)
        {
            var result = new List<Room>();
            using var connection = new NpgsqlConnection(Db.slaveConnectionString);
            await connection.OpenAsync();

            using var cmd = new NpgsqlCommand
            {
                Connection = connection,
                CommandText = @"
            SELECT * FROM room
            WHERE room_id NOT IN (
                SELECT room_id 
                FROM booking 
                WHERE rent_date <= @RentEndDate 
                AND rent_date + (rent_duration * INTERVAL '1 day') >= @RentStartDate
            )
            ORDER BY max_capacity ASC;"
            };
            cmd.Parameters.AddWithValue("RentStartDate", rentStartDate);
            cmd.Parameters.AddWithValue("RentEndDate", rentEndDate);

            using var reader = await cmd.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                result.Add(new Room(
                    room_id: reader.GetInt16(0),
                    hotel_id: reader.GetInt16(1),
                    room_type: Enum.Parse<RoomType>(reader.GetString("room_type")),
                    floor: reader.GetInt16(3),
                    max_capacity: reader.GetInt16(4)));
            }
            return result;
        }

        [HttpGet("GetFreeRoomsByTypeDesc")]
        public async Task<IEnumerable<Room>> GetFreeRoomsFilterRoomTypeDescending(DateTime rentStartDate, DateTime rentEndDate)
        {
            var result = new List<Room>();
            using var connection = new NpgsqlConnection(Db.slaveConnectionString);
            await connection.OpenAsync();

            using var cmd = new NpgsqlCommand
            {
                Connection = connection,
                CommandText = @"
                    SELECT * FROM room
            WHERE room_id NOT IN (
                SELECT room_id 
                FROM booking 
                WHERE rent_date <= @RentEndDate 
                AND rent_date + (rent_duration * INTERVAL '1 day') >= @RentStartDate
            )
            ORDER BY room_type DESC;"
            };
            cmd.Parameters.AddWithValue("RentStartDate", rentStartDate);
            cmd.Parameters.AddWithValue("RentEndDate", rentEndDate);

            using var reader = await cmd.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                result.Add(new Room(
                    room_id: reader.GetInt16(0),
                    hotel_id: reader.GetInt16(1),
                    room_type: Enum.Parse<RoomType>(reader.GetString("room_type")),
                    floor: reader.GetInt16(3),
                    max_capacity: reader.GetInt16(4)));
            }
            return result;
        }

        [HttpGet("GetFreeRoomsByTypeAsc")]
        public async Task<IEnumerable<Room>> GetFreeRoomsFilterRoomTypeAscending(DateTime rentStartDate, DateTime rentEndDate)
        {
            var result = new List<Room>();
            using var connection = new NpgsqlConnection(Db.slaveConnectionString);
            await connection.OpenAsync();

            using var cmd = new NpgsqlCommand
            {
                Connection = connection,
                CommandText = @"
                    SELECT * FROM room
            WHERE room_id NOT IN (
                SELECT room_id 
                FROM booking 
                WHERE rent_date <= @RentEndDate 
                AND rent_date + (rent_duration * INTERVAL '1 day') >= @RentStartDate
            )
            ORDER BY room_type ASC;"
            };
            cmd.Parameters.AddWithValue("RentStartDate", rentStartDate);
            cmd.Parameters.AddWithValue("RentEndDate", rentEndDate);

            using var reader = await cmd.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                result.Add(new Room(
                    room_id: reader.GetInt16(0),
                    hotel_id: reader.GetInt16(1),
                    room_type: Enum.Parse<RoomType>(reader.GetString("room_type")),
                    floor: reader.GetInt16(3),
                    max_capacity: reader.GetInt16(4)));
            }
            return result;
        }
    }
}
