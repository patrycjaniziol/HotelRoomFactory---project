using System;
using System.Collections.Generic;
using System.Text;

namespace HotelRoomFactory
{
    public class Room : HotelStaff
    {
        public int RoomNumber { get;}

        public string RoomState { get; set; }

        public Room(int id, DateTime dateTime, int roomNumber, string roomState) : base(id, dateTime)
        {
            RoomNumber = roomNumber;
            RoomState = roomState;
        }

        public override void GetState()
        {
            Console.WriteLine("Pokój nr: " + this.RoomNumber + ", aktualny stan: " + this.RoomState);
        }

        public override void Clean()
        {
            RoomState = ServiceState.Cleaning;
            ModificationDate = DateTime.UtcNow;
        }

        public override void Free()
        {
            RoomState = ServiceState.Free;
            ModificationDate = DateTime.UtcNow;
        }

        public override void Occupied()
        {
            RoomState = ServiceState.Occupied;
            ModificationDate = DateTime.UtcNow;
        }

        public override void Reserve()
        {
            RoomState = ServiceState.Reserved;
            ModificationDate = DateTime.UtcNow;
        }
    }
}
