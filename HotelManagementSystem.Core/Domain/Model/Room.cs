using HotelManagementSystem.Core.Domain.ValueObjects;

namespace HotelManagementSystem.Core.Domain.Model
{
    public class Room
    {
        private readonly Guid _id;
        public Guid Id => _id;
        public short RoomNr { get; private set; }
        public RoomType RoomType { get; private set; }

        private Room()
        {
        }
    }
}