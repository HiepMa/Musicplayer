using SQLite;
using System.Diagnostics;
using System.IO;
using training.Model;
using Windows.Storage;

namespace training.DB.engine.SQLiteDB {
    class SQLiteDatabase : IDatabase {
        public ISongDao SongDao => new SQLiteSongDaoImpl();
        public IPlaylistDao PlaylistDao => new SQLitePlaylistDaoImpl();

        ISongDao IDatabase.SongDao => this.SongDao;
        IPlaylistDao IDatabase.PlaylistDao => this.PlaylistDao;

        public static SQLiteConnection db;

        public SQLiteDatabase(string db_path = "") {
            /* Constructor for SQLite. */
            if (db_path == "")  // If not provide DB file path, choose a local folder as default.
                db_path = Path.Combine(Path.Combine(ApplicationData.Current.LocalFolder.Path, "db.sqlite"));

            Debug.WriteLine("======<<<DEBUG ONLY>>>=====");
            Debug.WriteLine(db_path);
            Debug.WriteLine("===========================");

            db = new SQLiteConnection(db_path);
            db.CreateTable<Song>();
            db.CreateTable<Playlist>();
            db.CreateTable<PlaylistSong>();
        }
    }
}
