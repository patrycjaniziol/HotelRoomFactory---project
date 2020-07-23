using System;
using System.Collections.Generic;
using System.Text;

namespace HotelRoomFactory
{
    class Receiver
    {
        public List<HotelStaff> reserveOperations = new List<HotelStaff>();

        public void Reserve(HotelStaff room)
        {
            room.Reserve();
            reserveOperations.Add(room);
        }

        public void Free(HotelStaff room)
        {
            room.Free();
        }
    }
}
