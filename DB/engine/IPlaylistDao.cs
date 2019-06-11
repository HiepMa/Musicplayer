using System.Collections.Generic;
using training.DB.model;

namespace training.DB.engine
{
    interface IPlaylistDao : IGenericDao<Playlist>
    {
        void addSong(Song s);

        List<Song> getSong(int playlistId);
    }
}
