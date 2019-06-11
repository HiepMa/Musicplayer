using SQLite.Net.Attributes;

namespace training.Model
{
    [Table("Playlist")]
    public class PlaylistEntity
    {
        [PrimaryKey]
        public int Id { get; set; }
        public string Name { get; set; }

    }
}
