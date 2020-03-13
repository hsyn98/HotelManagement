using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagement.Models
{
    public interface IRoomRepository
    {
        Room Add(Room room);
        Room Update(Room roomChanges);
        Room Delete(int id);
        Room GetRoom(int id);
        IEnumerable<Room> GetAllRooms(int id);
    }
}
