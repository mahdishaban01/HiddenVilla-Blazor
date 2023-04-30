namespace Business.Repository.IRepository
{
    public interface IHotelRoomRepository : IAsyncDisposable
    {
        public Task<IEnumerable<HotelRoomDTO>> GetAllHotelRooms();
        public Task<HotelRoomDTO> GetHotelRoom(int roomId);
        public Task<HotelRoomDTO> CreateHotelRoom(HotelRoomDTO hotelRoomDTO);
        public Task<HotelRoomDTO> UpdateHotelRoom(int roomId, HotelRoomDTO hotelRoomDTO);
        public Task<int> DeleteHotelRoom(int roomId);
        public Task<HotelRoomDTO> IsRoomUnique(string name);
    }
}
