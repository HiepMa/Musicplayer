using System;
using System.Collections.Generic;

namespace training.DB.engine.inmem
{
    class GenericDaoImpl : IGenericDao<IRecord>
    {
        private int autoId = 0;
        List<IRecord> List = new List<IRecord>();

        public int Insert(IRecord r)
        {
            autoId++;
            r.Id = autoId;
            this.List.Add(r);
            return autoId;
        }

        public int Update(IRecord r)
        {
            throw new NotImplementedException();
        }

        public int Delete(int id)
        {
            this.List.RemoveAll(r => r.Id == id);

            return 0;
        }

        public List<IRecord> getAll()
        {
            return this.List;
        }

        public IRecord getByID(int id)
        {
            return this.List.Find(r => r.Id == id);
        }
    }
}
