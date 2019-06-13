using System;
using System.Collections.Generic;

namespace training.DB.engine.SQLiteDB {
    class SQLiteGenericDaoImpl : IGenericDao<IRecord> {
        /* For real database, these methods only implement in specific DAO's implement. */
        public int Insert(IRecord t) {
            throw new NotImplementedException();
        }

        public int Update(IRecord T) {
            throw new NotImplementedException();
        }

        public int Delete(int id) {
            throw new NotImplementedException();
        }

        public IRecord getByID(int id) {
            throw new NotImplementedException();
        }

        public List<IRecord> getAll() {
            throw new NotImplementedException();
        }
    }
}
