using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemMap.Models.Transform.db
{
    public abstract class DataSourceNodeBase
    {
        protected string txt;
        protected List<DataSourceNodeBase> subNodes;

        protected DataSourceNodeBase(string txt, SqlConnectionStringBuilder builder)
        {
            this.ConnectionStringBuilder = builder;
            this.txt = txt;
        }

        protected SqlConnectionStringBuilder ConnectionStringBuilder { get; set; }

        public List<DataSourceNodeBase> Nodes
        {
            get
            {
                if (subNodes == null) subNodes = new List<DataSourceNodeBase>();
                return subNodes;
            }
        }

        public virtual void Load()
        {
            Reload();
        }

        public virtual void Reload()
        {
            if (subNodes == null)
            {
                subNodes = new List<DataSourceNodeBase>();
            }
            Nodes.Clear();
            this.LoadDatabaseObjects();
        }

        protected abstract void LoadDatabaseObjects();

        public override string ToString()
        {
            return txt;
        }
    }
}
