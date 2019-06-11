using System.Collections.Generic;
using training.DB.model;

namespace training.DB.engine.inmem
{
    class SongDaoImpl : GenericDaoImpl, ISongDao
    {
        public int Insert(Song s)
        {
            return base.Insert(s);
        }

        public int Update(Song s)
        {
            return base.Update(s);
        }

        List<Song> IGenericDao<Song>.getAll()
        {
            List<Song> list = new List<Song>();

            base.getAll().ForEach(delegate(IRecord record) {
                list.Add((Song)record);
            });

            return list;
        }

        Song IGenericDao<Song>.getByID(int id)
        {
            return (Song) this.getByID(id);
        }
    }
}
