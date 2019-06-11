using SQLite.Net.Attributes;
using System;

namespace training.Model
{
    [Table("Song")]
    public class SongEntity
    {
        [PrimaryKey]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }

    }
}
