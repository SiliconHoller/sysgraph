using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using SystemMap.Entities.data;
using SystemMap.Entities.service;
using SystemMap.Models;

namespace SystemMap.Entities.util
{
    public class DbSeed
    {
        private string[] nodeEnums = { "DbClasses", "ItActorTypes", "CrmEntities" };
        private string[] edgeEnums = { "RecordKeys","RecordOperations", "InterSystemConnectivity", "DbProcesses", "CrmProcesses" };
        private string[] attrEnums = { "DbColumnAttributes", "CrmDataTypes", "ValueTypes" };
        private string[] memEnums = { "DbClasses", "ResidencyTypes" };
        private string[] docEnums = { "DocTypes" };


        public void SeedTypeData()
        {
            using (TypeService tsvc = new TypeService())
            {
                string descr = "Automatically seeded type data";
                Assembly assm = Assembly.LoadFrom(@".\SystemMap.dll");
                List<Type> tlist = assm.GetTypes().Where(t => t.IsEnum).ToList<Type>();
                foreach (string ntype in nodeEnums)
                {
                    Type nodeEnum = tlist.Where(en => en.Name == ntype).SingleOrDefault();
                    if (nodeEnum != null)
                    {
                        FieldInfo[] nfields = nodeEnum.GetFields();
                        foreach (FieldInfo f in nfields)
                        {
                            if (f.Name.Equals("value__")) continue;
                            string showval = f.Name;
                            DisplayAttribute display = ((DisplayAttribute[])f.GetCustomAttributes(typeof(DisplayAttribute), false)).FirstOrDefault();
                            if (display != null) showval = display.GetName();
                            NodeType tdata = new NodeType { name = showval, description = descr };
                            NodeType added = tsvc.GetNodeType(tdata.name, true);
                        }
                    }
                }
                foreach (string etype in edgeEnums)
                {
                    Type edgeEnum = tlist.Where(en => en.Name == etype).SingleOrDefault();
                    if (edgeEnum != null)
                    {
                        FieldInfo[] nfields = edgeEnum.GetFields();
                        foreach (FieldInfo f in nfields)
                        {
                            if (f.Name.Equals("value__")) continue;
                            string showval = f.Name;
                            DisplayAttribute display = ((DisplayAttribute[])f.GetCustomAttributes(typeof(DisplayAttribute), false)).FirstOrDefault();
                            if (display != null) showval = display.GetName();
                            EdgeType tdata = new EdgeType { name = showval, description = descr };
                            EdgeType added = tsvc.GetEdgeType(tdata.name, true);
                        }
                    } 
                }
                foreach (string atype in attrEnums)
                {
                    Type attEnum = tlist.Where(en => en.Name == atype).SingleOrDefault();
                    if (attEnum != null)
                    {
                        FieldInfo[] nfields = attEnum.GetFields();
                        foreach (FieldInfo f in nfields)
                        {
                            if (f.Name.Equals("value__")) continue;
                            string showval = f.Name;
                            DisplayAttribute display = ((DisplayAttribute[])f.GetCustomAttributes(typeof(DisplayAttribute), false)).FirstOrDefault();
                            if (display != null) showval = display.GetName();
                            AttributeType tdata = new AttributeType { name = showval, description = descr };
                            AttributeType added = tsvc.GetAttributeType(tdata.name, true);
                        }
                    }
                }
                foreach (string mtype in memEnums)
                {
                    Type memEnum = tlist.Where(en => en.Name == mtype).SingleOrDefault();
                    if (memEnum != null)
                    {
                        FieldInfo[] nfields = memEnum.GetFields();
                        foreach (FieldInfo f in nfields)
                        {
                            if (f.Name.Equals("value__")) continue;
                            string showval = f.Name;
                            DisplayAttribute display = ((DisplayAttribute[])f.GetCustomAttributes(typeof(DisplayAttribute), false)).FirstOrDefault();
                            if (display != null) showval = display.GetName();
                            MembershipType tdata = new MembershipType { name = showval, description = descr };
                            MembershipType added = tsvc.GetMembershipType(tdata.name, true);
                        }
                    }
                }

                foreach (string dtype in docEnums)
                {
                    Type docEnum = tlist.Where(en => en.Name == dtype).SingleOrDefault();
                    if (docEnum != null)
                    {
                        FieldInfo[] nfields = docEnum.GetFields();
                        foreach (FieldInfo f in nfields)
                        {
                            if (f.Name.Equals("value__")) continue;
                            string showval = f.Name;
                            DisplayAttribute display = ((DisplayAttribute[])f.GetCustomAttributes(typeof(DisplayAttribute), false)).FirstOrDefault();
                            if (display != null) showval = display.GetName();
                            DocType tdata = new DocType { name = showval, description = descr };
                            DocType added = tsvc.GetDocType(tdata.name, true);
                        }
                    }
                }
            }
        }

    }
}
