using training.DB.engine;

namespace training.DB
{
    interface IDatabase
    {
        ISongDao SongDao { get; }
        IPlaylistDao PlaylistDao { get; }
    }
}
