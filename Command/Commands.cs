using System;
using System.Collections.Generic;
using System.Text;

namespace HotelRoomFactory
{
   public interface ICommand
    {
        void Execute();
    }

    public interface UndoableCommand: ICommand
    {
        void Undo();
    }

    class ReserveCommand : UndoableCommand
    {
        private Receiver receiver;

        private HotelStaff room;

        public ReserveCommand(Receiver receiver, HotelStaff room)
        {
            this.receiver = receiver;
            this.room = room;
        }

        public void Execute()
        {
            this.receiver.Reserve(this.room);
        }

        public void Undo()
        {
            this.receiver.Free(this.room);
        }
    }
}
