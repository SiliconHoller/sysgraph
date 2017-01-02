using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SystemMap.Models.Transform.util
{
    public class EnumParser
    {
        public static string GetValueName(Enum e)
        {
            Type etype = e.GetType();
            string valname = Enum.GetName(etype, e);
            FieldInfo f = etype.GetField(e.ToString());
            if (f != null)
            {
                DisplayAttribute dispval = ((DisplayAttribute[])f.GetCustomAttributes(typeof(DisplayAttribute), false)).FirstOrDefault();
                if (dispval != null) valname = dispval.GetName();
            }
            return valname;
        }
    }
}
