using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemMap.Models.Transform.db.sqlserver;

namespace SystemMap.Models.Transform.db.utils
{
    public abstract class DbInspector
    {
        protected DataServerStructure serverStructure;
        protected SqlConnectionStringBuilder connBuilder;

        protected DbInspector(SqlConnectionStringBuilder cbuilder)
        {
            this.connBuilder = cbuilder;
        }


        public static DbInspector GetInstance(SqlConnectionStringBuilder sqlbuilder)
        {
            DbInspector retval = null;
            string connType = sqlbuilder.GetType().FullName;
            switch (connType)
            {
                case "System.Data.SqlClient.SqlConnectionStringBuilder":
                    retval = new SqlServerInspector(sqlbuilder);
                    break;
                default:
                    retval = null;
                    break;
            }
            return retval;
        }

        public abstract DataServerStructure InitStructure();

        public abstract void LoadData();

        public abstract void ReloadData();

        public abstract bool PersistMap();

        public abstract void LoadDataSource(DataSourceStructure dbstruct);
    }
}
