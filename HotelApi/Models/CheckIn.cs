using System;
namespace HotelApi.Models
{
    public class CheckIn
    {
        public int itbId { get; set; }
        public int  roomId { get; set; }
        public string bookedBy { get; set; }
        public DateTime checkInTime { get; set; }
        public DateTime checkOutTime { get; set; }
    }
}
