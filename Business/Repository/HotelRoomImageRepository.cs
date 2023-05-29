namespace Business.Repository
{
    public class HotelRoomImageRepository : IHotelRoomImageRepository
    {
        #region Constructor

        private readonly HiddenVillaContext _context;
        private readonly IMapper _mapper;
        public HotelRoomImageRepository(HiddenVillaContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }

        #endregion

        #region Methods

        public async Task<IEnumerable<HotelRoomImageDTO>> GetHotelRoomImages(int roomId)
        {
            return _mapper.Map<IEnumerable<HotelRoomImage>, IEnumerable<HotelRoomImageDTO>>(
            await _context.HotelRoomImages.Where(x => x.RoomId == roomId).ToListAsync());
        }

        public async Task<int> CreateHotelRoomImage(HotelRoomImageDTO imageDTO)
        {
            var image = _mapper.Map<HotelRoomImageDTO, HotelRoomImage>(imageDTO);
            await _context.HotelRoomImages.AddAsync(image);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteHotelRoomImageByImageId(int imageId)
        {
            var image = await _context.HotelRoomImages.FindAsync(imageId);
            _context.HotelRoomImages.Remove(image);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteHotelRoomImageByRoomId(int roomId)
        {
            var imageList = await _context.HotelRoomImages.Where(x => x.RoomId == roomId).ToListAsync();
            _context.HotelRoomImages.RemoveRange(imageList);
            return await _context.SaveChangesAsync();
        }

        #endregion

        #region Dispose

        public async ValueTask DisposeAsync()
        {
            if(_context!=null)
                await _context.DisposeAsync();
        }

        #endregion
    }
}
