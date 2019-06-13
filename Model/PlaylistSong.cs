using SQLite;

namespace training.Model
{
    class PlaylistSong
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int PlaylistId { get; set; }
        public int SongId { get; set; }
    }
}
