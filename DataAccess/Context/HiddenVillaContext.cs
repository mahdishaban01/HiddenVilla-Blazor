using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Context
{
    public class HiddenVillaContext : DbContext
    {
        #region Constructor

        public HiddenVillaContext(DbContextOptions<HiddenVillaContext> options) : base(options) { }

        #endregion

        #region Entities

        public DbSet<HotelRoom> HotelRooms { get; set; }
        public DbSet<HotelRoomImage> HotelRoomImages { get; set; }

        #endregion
    }
}
