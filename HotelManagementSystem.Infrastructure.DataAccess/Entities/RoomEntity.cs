﻿namespace HotelManagementSystem.Infrastructure.DataAccess.Entities
{
    public class RoomEntity
    {
        public Guid Id { get; }
        public short RoomNr { get; private set; }

        public RoomEntity(Guid id, short roomNr)
        {
            Id = id;
            RoomNr = roomNr;
        }
    }
}
