using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemMap.Enums
{
    /// <summary>
    /// Generic definitions of DB entitype types
    /// </summary>
    public enum DbClasses
    {
        [Display(Name="Database")]
        Database,

        [Display(Name="Table")]
        Table,

        [Display(Name="View")]
        View,

        [Display(Name="User Account")]
        Login,

        [Display(Name="Report")]
        Report
    }

    public enum DbProcesses
    {
        [Display(Name = "StoredProcedure")]
        StoredProcedue,

        [Display(Name = "Function")]
        Function,

        [Display(Name = "Trigger")]
        Trigger,

        [Display(Name = "Job")]
        Job
        
    }
}
