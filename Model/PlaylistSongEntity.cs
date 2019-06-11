using SQLite.Net.Attributes;

namespace training.Model
{
    [Table("PlaylistSong")]
    public class PlaylistSongEntity
    {
        [PrimaryKey]
        public int Id { get; set; }
        public int SongId { get; set; }
        public int PlaylistId { get; set; }

    }
}
