using HotelManagementSystem.Core.Domain.Model;
using HotelManagementSystem.Core.Domain.ValueObjects;
using HotelManagementSystem.Infrastructure.DataAccess.Tables;
using System.Reflection;

namespace HotelManagementSystem.Infrastructure.DataAccess.Mappers
{
    internal class RoomMapper
    {
        // NOTE!
        // Reflection is used here due to the lack of Dapper functionality when it comes to mapping multiple
        // tables to one object that is well encapsulated with private setters
        public static Room ToDomain(RoomTable roomTable, RoomTypeTable roomTypeTable)
        {
            var roomType = typeof(Room);
            var ctor = roomType.GetConstructor(BindingFlags.Instance | BindingFlags.NonPublic, new Type[0]);
            var room = (Room)ctor.Invoke(null);

            var roomIdBackField = roomType.GetField("_id", BindingFlags.Instance | BindingFlags.NonPublic);
            roomIdBackField.SetValue(room, roomTable.Id);

            var roomRoomNrProperty = roomType.GetProperty("RoomNr", BindingFlags.Instance | BindingFlags.Public);
            roomRoomNrProperty.SetValue(room, roomTable.RoomNr);

            var roomRoomTypeProperty = roomType.GetProperty("RoomType", BindingFlags.Instance | BindingFlags.Public);
            roomRoomTypeProperty.SetValue(room, ToDomain(roomTypeTable));

            return room;
        }

        private static RoomType ToDomain(RoomTypeTable roomTypeTable)
        {
            var roomTypeType = typeof(RoomType);
            var ctor = roomTypeType.GetConstructor(BindingFlags.Instance | BindingFlags.NonPublic, new Type[] { typeof(string), typeof(bool), typeof(bool) });
            var roomType = (RoomType)ctor.Invoke(new object[] { roomTypeTable.Type, roomTypeTable.HasCityView, roomTypeTable.HasBathtub });

            return roomType;
        }
    }
}
