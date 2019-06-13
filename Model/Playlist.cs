using SQLite;
using training.DB.engine;

namespace training.Model
{
    class Playlist : IRecord
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
