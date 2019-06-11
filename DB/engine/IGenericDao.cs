using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace training.DB.engine
{
    interface IGenericDao<T>
    {
        int Insert(T t);
        int Update(T T);
        int Delete(int id);

        List<T> getAll();
        T getByID(int id);
    }
}
