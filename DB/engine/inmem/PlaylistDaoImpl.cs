using System;
using System.Collections.Generic;
using training.Model;

namespace training.DB.engine.inmem
{
    class PlaylistDaoImpl : GenericDaoImpl, IPlaylistDao
    {
        private int autoId = 0;
        List<PlaylistSong> pls = new List<PlaylistSong>();
        public void addSong(Song s, Playlist p)
        {
            autoId++;
            PlaylistSong pl = new PlaylistSong();
            pl.Id = autoId;
            pl.PlaylistId = p.Id;
            pl.SongId = s.Id;
            this.pls.Add(pl);
        }

        public List<Song> getSong(int playlistId)
        {
            List<Song> list = new List<Song>();

            this.pls.ForEach(delegate (PlaylistSong pls) {
                if (pls.PlaylistId == playlistId) {
                    var result = DatabaseService.Instance().DB.SongDao.getByID(pls.SongId);
                    if (result != null)
                        list.Add(result);
                }
            });

            return list;
        }

        public int Insert(Playlist p)
        {
            return base.Insert(p);
        }

        public int Update(Playlist p)
        {
            return base.Update(p);
        }

        List<Playlist> IGenericDao<Playlist>.getAll()
        {
            List<Playlist> list = new List<Playlist>();

            base.getAll().ForEach(delegate (IRecord record) {
                list.Add((Playlist)record);
            });

            return list;
        }

        Playlist IGenericDao<Playlist>.getByID(int id)
        {
            return (Playlist)this.getByID(id);
        }
    }
}
