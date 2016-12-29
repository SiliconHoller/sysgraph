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

        public string Name { get { return txt; } }

        public List<DataSourceNodeBase> ResidentNodes { get; set; }

        public int NodeIdentity { get; set; }

        public List<NodeAttribute> Metadata { get; set; }

        public List<DataConnection> Relationships { get; set; }

        public virtual void LoadSubNodes()
        {
            if (subNodes == null || subNodes.Count == 0) ReloadSubNodes();
        }

        public virtual void ReloadSubNodes()
        {
            if (subNodes == null)
            {
                subNodes = new List<DataSourceNodeBase>();
            }
            Nodes.Clear();
            this.LoadDatabaseObjects();
        }

        public virtual void LoadMetadata()
        {
            if (Metadata == null || Metadata.Count == 0) ReloadMetadata();
        }

        public virtual void ReloadMetadata()
        {
            if (Metadata == null) Metadata = new List<NodeAttribute>();
            Metadata.Clear();
            this.LoadDatabaseAttributes();
        }

        public virtual void LoadRelationships()
        {
            if (Relationships == null || Relationships.Count == 0) ReloadRelationships();
        }

        public virtual void ReloadRelationships()
        {
            if (Relationships == null) Relationships = new List<DataConnection>();
            Relationships.Clear();
            this.LoadDatabaseRelationships();
        }

        protected abstract void LoadDatabaseObjects();

        protected abstract void LoadDatabaseRelationships();

        protected abstract void LoadDatabaseAttributes();

        public override string ToString()
        {
            return txt;
        }

        public override bool Equals(object obj)
        {
            bool retval = false;
            if (obj == null) return false;
            if (obj is DataSourceNodeBase)
            {
                DataSourceNodeBase onode = (DataSourceNodeBase)obj;
                if (NodeIdentity != 0 && onode.NodeIdentity != 0)
                {
                    retval = NodeIdentity == onode.NodeIdentity;
                }
                else
                {
                    //compare types and names
                    if (!String.IsNullOrEmpty(Name) && !String.IsNullOrEmpty(onode.Name) && this.GetType() == obj.GetType())
                    {
                        retval = Name.Equals(onode.Name);
                    }
                }
            }
            return retval;
        }
    }
}
