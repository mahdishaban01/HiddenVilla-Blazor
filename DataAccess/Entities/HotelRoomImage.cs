namespace DataAccess.Entities
{
    public class HotelRoomImage
    {
        #region Properties

        [Key]
        public int Id { get; set; }

        public int RoomId { get; set; }

        public string RoomImageUrl { get; set; }

        #endregion

        #region Relations

        [ForeignKey("RoomId")]
        public virtual HotelRoom HotelRoom { get; set; }

        #endregion
    }
}
