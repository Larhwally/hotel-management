using System;
using System.Collections.Generic;
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
        public List<Room> GetRooms()
        {
            List<Room> rooms = new List<Room>();

            using(MySqlConnection connection = GetConnection())
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand("Select * from tbl_room", connection);

                using(var reader = command.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        rooms.Add(new Room()
                        {
                            itbId = Convert.ToInt32(reader["itbId"]),
                            roomNumber = Convert.ToInt32(reader["roomNumber"]),
                            roomStatus = reader["roomStatus"].ToString()
                        });
                    }
                }
            }
            return rooms;
        }

    }
}
