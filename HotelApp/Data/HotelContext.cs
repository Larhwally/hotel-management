using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HotelApi.Models;
using MySql.Data.MySqlClient;

namespace HotelApi.Data
{
    public class HotelContext
    {
        public string ConnectionString { get; set; }

        public HotelContext(string connection)
        {
            this.ConnectionString = connection;
        }

        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }

        //A method to get the list of all rooms
        public async Task <List<Room>> GetRooms()
        {
            List<Room> rooms = new List<Room>();

            using(MySqlConnection connection = GetConnection())
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand("Select * from tbl_room", connection);

                await using var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    rooms.Add(new Room()
                    {
                        itbId = Convert.ToInt32(reader["itbId"]),
                        roomNumber = (reader["roomNumber"]).ToString(),
                        roomStatus = reader["roomStatus"].ToString()
                    });
                }
            }
            return rooms;
        }


        //A method to add new room detail to the db
        public async Task<bool> PostRoom(Room room)
        {

            await using MySqlConnection connection = GetConnection();
            connection.Open();
            MySqlCommand command = new MySqlCommand("INSERT INTO tbl_room(roomNumber, roomStatus) VALUES(@roomNumber, @roomStatus)", connection);

            command.Parameters.AddWithValue("@roomNumber", room.roomNumber);
            command.Parameters.AddWithValue("@roomStatus", room.roomStatus);

            int n = command.ExecuteNonQuery();
            return n > 0;
        }


        //A method to get room detail by id
        //public async Task<Dictionary<string, object>> GetRoomById(int id)
        //{
        //    Dictionary<string, object> result = new Dictionary<string, object>();
        //    using (MySqlConnection connection = GetConnection())
        //    {
        //        connection.Open();
        //        MySqlCommand command = new MySqlCommand("SELECT * FROM tbl_room WHERE itbId = " + id, connection);
        //        command.Parameters.AddWithValue("@itbId", id);

        //        await using var reader = command.ExecuteReader();
        //        while (reader.Read())
        //        {
        //            for (int i = 0; i < reader.FieldCount; i++)
        //            {
        //                result.Add(reader.GetName(i), reader.GetValue(i)); 
        //            }
        //        }

        //    }
        //    return result;
            
        //}

        //-------------------------------Rewrite this method-----------------------------
        public async Task<Room> GetRoomById(int id)
        {
            Room room = new Room();
            Dictionary<string, object> result = new Dictionary<string, object>();
            using (MySqlConnection connection = GetConnection())
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand("SELECT * FROM tbl_room WHERE itbId = " + id, connection);
                command.Parameters.AddWithValue("@itbId", id);

                await using var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    {
                        room.itbId = Convert.ToInt32(reader["itbId"]);
                        room.roomNumber = (reader["roomNumber"]).ToString();
                        room.roomStatus = reader["roomStatus"].ToString();
                    };
                }

            }
            return room;

        }


    }
}
