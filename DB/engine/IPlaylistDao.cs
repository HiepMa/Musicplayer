using System.Collections.Generic;
using training.Model;

namespace training.DB.engine
{
    interface IPlaylistDao : IGenericDao<Playlist>
    {
        void addSong(Song s, Playlist p);

        List<Song> getSong(int playlistId);
    }
}
