using System;
using System.Collections.Generic;
using training.DB.model;

namespace training.DB.engine.inmem
{
    class PlaylistDaoImpl : GenericDaoImpl, IPlaylistDao
    {

        public void addSong(Song s)
        {
            throw new NotImplementedException();
        }

        public List<Song> getSong(int playlistId)
        {
            throw new NotImplementedException();
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
