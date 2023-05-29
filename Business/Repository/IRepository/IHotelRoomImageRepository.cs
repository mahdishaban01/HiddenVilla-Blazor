namespace Business.Repository.IRepository
{
    public interface IHotelRoomImageRepository : IAsyncDisposable
    {
        public Task<IEnumerable<HotelRoomImageDTO>> GetHotelRoomImages(int roomId);
        public Task<int> CreateHotelRoomImage(HotelRoomImageDTO image);
        public Task<int> DeleteHotelRoomImageByImageId(int imageId);
        public Task<int> DeleteHotelRoomImageByRoomId(int roomId);
    }
}
