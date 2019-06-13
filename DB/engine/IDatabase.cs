using training.DB.engine;

namespace training.DB.engine {
    interface IDatabase
    {
        ISongDao SongDao { get; }
        IPlaylistDao PlaylistDao { get; }
    }
}
