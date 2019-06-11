using System;
using training.DB.engine;

namespace training.DB
{
    class DatabaseService
    {
        private static DatabaseService _instance;
        public IDatabase DB;

        protected DatabaseService() {
            this.DB = new InMemoryDatabase();
        }

        protected DatabaseService(string type)
        {
            switch(type)
            {
                case "inmem":
                    this.DB = new InMemoryDatabase();
                    break;
                default:
                    throw new NotImplementedException();
            }
        }

        public static DatabaseService Instance()
        {
            // Uses lazy initialization.

            // Note: this is not thread safe.

            if (_instance == null)
            {
                _instance = new DatabaseService();
            }

            return _instance;
        }
    }
}
