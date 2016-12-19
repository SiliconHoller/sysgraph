using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemMap.Enums
{
    /// <summary>
    /// CRM Records of interest
    /// </summary>
    public enum CrmEntities
    {
        [Display(Name="Lead Records")]
        Lead,
        [Display(Name="Contact Records")]
        Contact,
        [Display(Name="Opportunity Records")]
        Opportunity,
        [Display(Name="Task Records")]
        Task,
        [Display(Name="User Records")]
        User
    }

    /// <summary>
    /// Crm-specific internal processes
    /// </summary>
    public enum CrmProcesses
    {
        [Display(Name="Internal Workflow")]
        Workflow,
        [Display(Name="Web Service Operation")]
        WebService,
        [Display(Name="Bulk Update Operation")]
        BulkUpdate,
        [Display(Name="Export")]
        BulkExport,
        [Display(Name="Import")]
        BulkImport,
        [Display(Name="User Interaction")]
        UserAction,
        [Display(Name="Integration Queue")]
        IntegrationQueue,
        [Display(Name="Automated Email")]
        Email
    }
}
