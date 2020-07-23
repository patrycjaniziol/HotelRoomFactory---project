using Newtonsoft.Json;
using System;

namespace HotelRoomFactory
{
    class Program
    {
        private static void  ShowMenu()
        {
            Console.WriteLine("1.Change floor");
            Console.WriteLine("2.Make reservation");
            Console.WriteLine("3.Make it free");
            Console.WriteLine("4.Make it clean");
            Console.WriteLine("5.Make it occupied");
            Console.WriteLine("6.Check state");
            Console.WriteLine("7. Undo");
            Console.WriteLine("8.Close");
        }
        static void Main(string[] args)
        {
            string state;
            CommandManager invoker = new CommandManager();
            Receiver receiver = new Receiver();
            Console.WriteLine("Budujemy hotel przy pomocy buildera");
            var hotel = new Builder(0, 0);
            hotel.AddFloor(1, 1);
            hotel.CurrentFloor.Add(new Room(11, DateTime.Now, 11, ServiceState.Free));
            hotel.CurrentFloor.Add(new Room(12, DateTime.Now, 12, ServiceState.Free));
            hotel.CurrentFloor.Add(new Room(13, DateTime.Now, 13, ServiceState.Free));
            hotel.CurrentFloor.Add(new Room(14, DateTime.Now, 14, ServiceState.Free));
            hotel.SetCurrentFloor(0);
            Console.WriteLine(hotel.CurrentFloor.FloorNumber);
            hotel.AddFloor(2, 2);
            hotel.CurrentFloor.Add(new Room(21, DateTime.Now, 21, ServiceState.Free));
            hotel.CurrentFloor.Add(new Room(22, DateTime.Now, 22, ServiceState.Free));
            hotel.CurrentFloor.Add(new Room(23, DateTime.Now, 23, ServiceState.Free));
            hotel.CurrentFloor.Add(new Room(24, DateTime.Now, 24, ServiceState.Free));
            Console.WriteLine(hotel.CurrentFloor.FloorNumber);
            Console.WriteLine(JsonConvert.SerializeObject(hotel.Hotel, Formatting.Indented));
            Console.WriteLine("Zakończono budowę hotelu");
            Console.WriteLine("Możesz przystąpić do zarządzanie hotelem");
            do
            {
                ShowMenu();
                Console.WriteLine("Wybierz");
                state = Console.ReadLine();
                switch (int.Parse(state))
                {
                    case 1:
                        Console.WriteLine("0 - Hotel");
                        Console.WriteLine("1 - 1 Floor");
                        Console.WriteLine("2 - 2 Floor");
                        Console.WriteLine("Choose floor");
                        string floor = Console.ReadLine();
                        hotel.SetCurrentFloor(int.Parse(floor));
                        Console.WriteLine("You are on floor nr: " + hotel.CurrentFloor.FloorNumber);
                        break;
                    case 2:
                        Console.WriteLine("Reserve all floor or room");
                        Console.WriteLine("1 - Floor, 2 - Room");
                        string rOption = Console.ReadLine();
                        if (int.Parse(rOption) == 2)
                        {
                            int number = 0;
                            foreach (Room room in hotel.CurrentFloor.rooms)
                            {
                                Console.WriteLine("Pokój nr: " + room.RoomNumber + " type: " + number);
                                number++;
                                
                            }
                           
                            string result = Console.ReadLine();
                            invoker.ExecuteCommand(new ReserveCommand(receiver, hotel.CurrentFloor.rooms[int.Parse(result)]));
                        }
                        else if (int.Parse(rOption) == 1)
                        {
                            invoker.ExecuteCommand(new ReserveCommand(receiver, hotel.CurrentFloor));
                        }
                        else
                        {
                            Console.WriteLine("Incorrect operation number");
                        }
                        break;
                    case 3:
                        Console.WriteLine("Free all floor or room");
                        Console.WriteLine("1 - Floor, 2 - Room");
                        string fOption = Console.ReadLine();
                        if (int.Parse(fOption) == 2)
                        {
                            int number = 0;
                            foreach (Room room in hotel.CurrentFloor.rooms)
                            {
                                Console.WriteLine("Pokój nr: " + room.RoomNumber + "type: " + number);
                                number++;
                            }
                            string result = Console.ReadLine();
                            hotel.CurrentFloor.rooms[int.Parse(result)].Free();
                        }
                        else if (int.Parse(fOption) == 1)
                        {
                            hotel.CurrentFloor.Free();
                        }
                        else
                        {
                            Console.WriteLine("Incorrect operation number");
                        }
                        break;
                    case 4:
                        Console.WriteLine("Clean all floor or room");
                        Console.WriteLine("1 - Floor, 2 - Room");
                        string cOption = Console.ReadLine();
                        if (int.Parse(cOption) == 2)
                        {
                            int number = 0;
                            foreach (Room room in hotel.CurrentFloor.rooms)
                            {
                                Console.WriteLine("Pokój nr: " + room.RoomNumber + "type: " + number);
                                number++;
                            }
                            string result = Console.ReadLine();
                            hotel.CurrentFloor.rooms[int.Parse(result)].Clean();
                        }
                        else if (int.Parse(cOption) == 1)
                        {
                            hotel.CurrentFloor.Clean();
                        }
                        else
                        {
                            Console.WriteLine("Incorrect operation number");
                        }
                        break;
                    case 5:
                        Console.WriteLine("Occupied all floor or room");
                        Console.WriteLine("1 - Floor, 2 - Room");
                        string option = Console.ReadLine();
                        if (int.Parse(option) == 2)
                        {
                            int number = 0;
                            foreach (Room room in hotel.CurrentFloor.rooms)
                            {
                                Console.WriteLine("Pokój nr: " + room.RoomNumber + "type: " + number);
                                number++;
                            }
                            string result = Console.ReadLine();
                            hotel.CurrentFloor.rooms[int.Parse(result)].Occupied();
                        }
                        else if (int.Parse(option) == 1)
                        {
                            hotel.CurrentFloor.Occupied();
                        }
                        else
                        {
                            Console.WriteLine("Incorrect operation number");
                        }
                        break;
                    case 6:
                        Console.WriteLine("State all floor or room");
                        Console.WriteLine("1 - Floor, 2 - Room");
                        string sOption = Console.ReadLine();
                        if (int.Parse(sOption) == 2)
                        {
                            int number = 0;
                            foreach (Room room in hotel.CurrentFloor.rooms)
                            {
                                Console.WriteLine("Pokój nr: " + room.RoomNumber + "type: " + number);
                                number++;
                            }
                            string result = Console.ReadLine();
                            hotel.CurrentFloor.rooms[int.Parse(result)].GetState();
                        }
                        else if (int.Parse(sOption) == 1)
                        {
                            hotel.CurrentFloor.GetState();
                        }
                        else
                        {
                            Console.WriteLine("Incorrect operation number");
                        }
                        break;
                    case 7:
                        invoker.Undo();
                        break;

                }
            } while (int.Parse(state) < 8);
            
        }
    }
}
