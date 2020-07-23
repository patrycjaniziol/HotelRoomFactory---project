using System;
using System.Collections.Generic;
using System.Text;

namespace HotelRoomFactory
{
    public abstract class HotelStaff
    {
        public int Id { get; }

        public DateTime ModificationDate { get; set; }

        public HotelStaff(int id, DateTime dateTime)
        {
            Id = id;
            ModificationDate = dateTime;
        }

        public abstract void GetState();

        public abstract void Clean();

        public abstract void Reserve();

        public abstract void Occupied();

        public abstract void Free();

    }
}
