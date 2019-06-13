using System.Collections.Generic;
using training.Model;

namespace training.DB.engine.SQLiteDB {
    class SQLitePlaylistDaoImpl : SQLiteGenericDaoImpl, IPlaylistDao {
        public int Insert(Playlist p) {
            return SQLiteDatabase.db.Insert(p);
        }

        public int Update(Playlist p) {
            return SQLiteDatabase.db.Update(p);
        }

        public new int Delete(int id) {
            var query = SQLiteDatabase.db.Table<Playlist>().Where(v => v.Id == id);

            // If playlist not in database, return -1
            if (query.Count() < 1)
                return -1;

            Playlist p = query.First();
            SQLiteDatabase.db.Delete(p);
            return p.Id;
        }

        public void addSong(Song s, Playlist p) {
            var query = SQLiteDatabase.db.Table<Song>().Where(v => v.Id == s.Id);
            if (query.Count() > 0) {
                PlaylistSong pls = new PlaylistSong { PlaylistId = p.Id, SongId = s.Id };
                var _ = SQLiteDatabase.db.Insert(pls);  // For omit result return back from Insert query.
            }
        }

        public List<Song> getSong(int playlistId) {
            List<Song> list_song = new List<Song>();

            // Get all SongID with the same PlaylistID from PlaylistSong table.
            var query = SQLiteDatabase.db.Table<PlaylistSong>().Where(v => v.PlaylistId == playlistId);

            // If query empty, return an empty list.
            if (query.Count() < 1) {
                return new List<Song>();
            }

            // For each SongID, query it info from Song table.
            foreach (var songId in query) {
                Song song_info = SQLiteDatabase.db.Table<Song>().Where(v => v.Id == songId.SongId).First();
                list_song.Add(song_info);
            }

            return list_song;
        }

        List<Playlist> IGenericDao<Playlist>.getAll() {
            // Query all data from Playlist table into a new Playlist List and return it.
            var query = SQLiteDatabase.db.Table<Playlist>().Where(v => true);

            List<Playlist> listP = new List<Playlist>();
            foreach (var playlist in query)
                listP.Add(playlist);

            return listP;
        }

        Playlist IGenericDao<Playlist>.getByID(int id) {
            var query = SQLiteDatabase.db.Table<Playlist>().Where(v => v.Id == id);
            return query.First();
        }
    }
}
