namespace Business.Repository
{
    public class HotelRoomRepository : IHotelRoomRepository
    {
        #region Constructor

        private readonly HiddenVillaContext _context;
        private readonly IMapper _mapper;
        public HotelRoomRepository(HiddenVillaContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }

        #endregion

        #region Methods

        public async Task<IEnumerable<HotelRoomDTO>> GetAllHotelRooms()
        {
            var hotelRoomDTOs =
                _mapper.Map<IEnumerable<HotelRoom>, IEnumerable<HotelRoomDTO>>(_context.HotelRooms);

            return hotelRoomDTOs;
        }

        public async Task<HotelRoomDTO> GetHotelRoom(int roomId)
        {
            var hotelRoom = _mapper.Map<HotelRoom, HotelRoomDTO>(
                await _context.HotelRooms.SingleOrDefaultAsync(h => h.Id == roomId));

            return hotelRoom;
        }

        public async Task<HotelRoomDTO> CreateHotelRoom(HotelRoomDTO hotelRoomDTO)
        {
            var hotelRoom = _mapper.Map<HotelRoomDTO, HotelRoom>(hotelRoomDTO);
            hotelRoom.CreatedDate = DateTime.Now;
            hotelRoom.CreatedBy = "";
            var addedHotelRoom = await _context.HotelRooms.AddAsync(hotelRoom);
            await _context.SaveChangesAsync();
            return _mapper.Map<HotelRoom, HotelRoomDTO>(addedHotelRoom.Entity);
        }

        public async Task<HotelRoomDTO> UpdateHotelRoom(int roomId, HotelRoomDTO hotelRoomDTO)
        {
            if (roomId == hotelRoomDTO.Id)
            {
                //valid
                var roomDetails = await _context.HotelRooms.FindAsync(roomId);
                var room = _mapper.Map<HotelRoomDTO, HotelRoom>(hotelRoomDTO, roomDetails);
                room.UpdatedBy = "";
                room.UpdatedDate = DateTime.Now;
                var updatedRoom = _context.HotelRooms.Update(room);
                await _context.SaveChangesAsync();
                return _mapper.Map<HotelRoom, HotelRoomDTO>(updatedRoom.Entity);
            }
            else
            {
                //invalid
                return null;
            }
        }

        public async Task<int> DeleteHotelRoom(int roomId)
        {
            var roomDetails = await _context.HotelRooms.FindAsync(roomId);
            if (roomDetails != null)
            {
                _context.HotelRooms.Remove(roomDetails);
                return await _context.SaveChangesAsync();
            }

            return 0;
        }

        public async Task<HotelRoomDTO> IsRoomUnique(string name, int roomId)
        {
            if (roomId == 0)
            {
                HotelRoomDTO hotelRoom = _mapper.Map<HotelRoom, HotelRoomDTO>(
                    await _context.HotelRooms.FirstOrDefaultAsync(x => x.Name.ToLower() == name.ToLower()));

                return hotelRoom;
            }
            else
            {
                HotelRoomDTO hotelRoom = _mapper.Map<HotelRoom, HotelRoomDTO>(
                    await _context.HotelRooms.FirstOrDefaultAsync(x => x.Name.ToLower() == name.ToLower()
                    && x.Id != roomId));

                return hotelRoom;
            }
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
