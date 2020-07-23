using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace HotelRoomFactory
{
    public class Builder
    {
        public Floor Hotel { get; }
        public Floor CurrentFloor { get; set; }

        public Builder(int id,int floorNumber)
        {
            Hotel = new Floor(id, DateTime.Now, floorNumber);
            CurrentFloor = Hotel;
        }

        public Room AddRoom(int id, int roomNumber, string roomState)
        {
            var room = new Room(id, DateTime.Now, roomNumber, roomState);
            CurrentFloor.Add(room);
            return room;
        }

        public Floor SetCurrentFloor(int id)
        {
            var floorStack = new Stack<Floor>();
            floorStack.Push(Hotel);
            while (floorStack.Any())
            {
                var currentFloor = floorStack.Pop();

                if(id == currentFloor.Id )
                {
                    CurrentFloor = currentFloor;
                    return currentFloor;
                }

                foreach (var room in currentFloor.rooms.OfType<Floor>())
                {
                    floorStack.Push(room);
                }
            }

            throw new InvalidOperationException();
        }

        public Floor AddFloor(int id, int floorNumber)
        {
            var floor = new Floor(id, DateTime.Now, floorNumber);
            CurrentFloor.Add(floor);
            CurrentFloor = floor;
            return floor;
        }
    }
}
