using SQLite;
using training.DB.engine;

namespace training.Model
{
    class Song : IRecord
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
    }
}
