using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace HotelRoomFactory
{
    public class Floor : HotelStaff
    {
        public List<HotelStaff> rooms { get; } = new List<HotelStaff>();

        public int FloorNumber { get; }

        public Floor(int id, DateTime dateTime, int floorNumber) : base(id,dateTime)
        {
            FloorNumber = floorNumber;
        }

        public void Add(HotelStaff newNode)
        {
            rooms.Add(newNode);
        }

        public void Remove(HotelStaff deleteNode)
        {
            rooms.Remove(deleteNode);
        }

        public override void Clean()
        {
            rooms.ForEach(x => x.Clean());
            GetState();
        }

        public override void Free()
        {
            rooms.ForEach(x => x.Free());
            GetState();
        }

        public override void Occupied()
        {
            rooms.ForEach(x => x.Occupied());
            GetState();
        }

        public override void Reserve()
        {
            rooms.ForEach(x => x.Reserve());
            GetState();
        }

        public override void GetState()
        {
            rooms.ForEach(x => x.GetState());
        }

        
    }
}
