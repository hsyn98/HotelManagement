using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagement.Models
{
    public class SQLRoomRepository : IRoomRepository
    {
        private readonly AppDbContext context;

        public SQLRoomRepository(AppDbContext context)
        {
            this.context = context;
        }

        public Room Add(Room room)
        {
            context.Rooms.Add(room);
            context.SaveChanges();
            return room;
        }

        public Room Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Room> GetAllRooms(int id)
        {
            return context.Rooms.Where(n => n.BranchId == id);
        }

        public Room GetRoom(int id)
        {
            return context.Rooms.Find(id);
        }

        public Room Update(Room roomChanges)
        {
            var room = context.Rooms.Attach(roomChanges);
            room.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return roomChanges;
        }
    }
}
