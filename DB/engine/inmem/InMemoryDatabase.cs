﻿namespace training.DB.engine.inmem {
    class InMemoryDatabase : IDatabase
    {
        public ISongDao SongDao = new SongDaoImpl();
        public IPlaylistDao PlaylistDao = new PlaylistDaoImpl();

        ISongDao IDatabase.SongDao => this.SongDao;

        IPlaylistDao IDatabase.PlaylistDao => this.PlaylistDao;
    }
}
