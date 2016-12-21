using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using SystemMap.Entities.data;

namespace SystemMap.Entities.util
{
    public class DbSeed
    {
        private string[] nodeEnums = { "DbClasses", "ItActorTypes", "CrmEntities" };
        private string[] edgeEnums = { "RecordKeys","RecordOperations", "InterSystemConnectivity", "DbProcesses", "CrmProcesses" };

        public void SeedTypeData()
        {
            using (SystemMapEntities db = new SystemMapEntities())
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
                            nodetype tdata = new nodetype { name = showval, descr = descr };
                            db.nodetypes.Add(tdata);
                            db.SaveChanges();
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
                            edgetype tdata = new edgetype { name = showval, descr = descr };
                            db.edgetypes.Add(tdata);
                            db.SaveChanges();
                        }
                    } 
                }
            }
        }

    }
}
