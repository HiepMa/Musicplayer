using System.Collections.Generic;
using training.Model;

namespace training.DB.engine.SQLiteDB {
    class SQLiteSongDaoImpl : SQLiteGenericDaoImpl, ISongDao {
        public int Insert(Song s) {
            return SQLiteDatabase.db.Insert(s);
        }

        public int Update(Song s) {
            return SQLiteDatabase.db.Update(s);
        }

        List<Song> IGenericDao<Song>.getAll() {
            var query = SQLiteDatabase.db.Table<Song>().Where(v => true);
            List<Song> listS = new List<Song>();
            foreach (var song in query)
                listS.Add(song);
            return listS;
        }

        Song IGenericDao<Song>.getByID(int id) {
            var query = SQLiteDatabase.db.Table<Song>().Where(v => v.Id == id);
            return query.First();
        }

        public new int Delete(int id) {
            var query = SQLiteDatabase.db.Table<Song>().Where(v => v.Id == id);
            
            if (query.Count() < 1)
                return -1;

            Song s = query.First();
            SQLiteDatabase.db.Delete(s);
            return s.Id;
        }
    }
}
