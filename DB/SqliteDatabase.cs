using SQLite.Net;
using System;
using training.DB.engine;
using training.Model;

namespace training.DB
{
    class SqliteDatabase : SQLiteDatabase, IDatabase
    {
        public Table<SongEntity> Song { get; set; }
        public Table<PlaylistEntity> Playlist { get; set; }
        public Table<PlaylistSongEntity> PlaylistSong { get; set; }

        public ISongDao SongDao => throw new NotImplementedException();

        public IPlaylistDao PlaylistDao => throw new NotImplementedException();

        public SqliteDatabase() : base(/** Optional path to file. **/)
        {
            if (UserVersion == 0)
            {
                CreateTable("Song", c => new
                {
                    Id = c.Column<int>(primaryKey: true),
                    Name = c.Column<string>(nullable: false),
                    Path = c.Column<string>(nullable: false),
                },
                t => new
                {
                    UniqueSongNames = t.Unique(p => p.Name)
                });

                CreateTable("Playlist", c => new
                {
                    Id = c.Column<int>(primaryKey: true),
                    Name = c.Column<string>(nullable: false),
                },
                t => new
                {
                    UniquePlaylistNames = t.Unique(p => p.Name)
                });

                CreateTable("PlaylistSong", c => new
                {
                    Id = c.Column<int>(primaryKey: true),
                    SongId = c.Column<int>(nullable: false),
                    PlaylistId = c.Column<int>(nullable: false),
                },
                t => new
                {
                    
                });

            }
            UserVersion++;
        }
    }
}
