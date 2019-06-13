using System.Collections.Generic;
using System.Collections.ObjectModel;
using training.DB.engine;
using training.DB.engine.inmem;
using training.DB.engine.SQLiteDB;
using training.Model;

namespace training.DB
{
    class DatabaseService
    {
        private static DatabaseService _instance;
        public IDatabase DB;

        protected DatabaseService() { }

        protected DatabaseService(string type)
        {
            switch(type)
            {
                case "inmem":
                    this.DB = new InMemoryDatabase();
                    break;
                case "sqlite":
                    this.DB = new SQLiteDatabase();
                    break;
                default:
                    break;
            }
        }

        public static DatabaseService Instance()
        {
            // Uses lazy initialization.

            // Note: this is not thread safe.

            if (_instance == null)
            {
                _instance = new DatabaseService("sqlite");
            }

            return _instance;
        }
        public void InsertSong(Song song)
        {
            this.DB.SongDao.Insert(song);
        }

        public void UpdateSong(Song song)
        {
            this.DB.SongDao.Update(song);
        }

        public void DeleteSong(int song_id)
        {
            this.DB.SongDao.Delete(song_id);
        }

        public List<Song> GetAllSong()
        {
            return this.DB.SongDao.getAll();
        }

        public Song GetSongById(int song_id)
        {
            return this.DB.SongDao.getByID(song_id);
        }

        /* ===> PLAYLIST DAO <=== */

        public void InsertPlaylist(Playlist playlist)
        {
            this.DB.PlaylistDao.Insert(playlist);
        }

        public void UpdatePlaylist(Playlist playlist)
        {
            this.DB.PlaylistDao.Update(playlist);
        }

        public void DeletePlaylist(int playlist_id)
        {
            this.DB.PlaylistDao.Delete(playlist_id);
        }

        public List<Playlist> GetAllPlaylist()
        {
            return this.DB.PlaylistDao.getAll();
        }

        public Playlist GetPlaylistById(int playlist_id)
        {
            return this.DB.PlaylistDao.getByID(playlist_id);
        }

        public void AddSong(Song song, Playlist playlist)
        {
            this.DB.PlaylistDao.addSong(song, playlist);
        }

        public List<Song> GetSongFromPlaylist(int playlist_id)
        {
            return this.DB.PlaylistDao.getSong(playlist_id);
        }
    }
}
