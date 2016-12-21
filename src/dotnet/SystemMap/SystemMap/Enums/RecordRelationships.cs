using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemMap.Enums
{
    /// <summary>
    /// Database key relationships between tables
    /// </summary>
    [Flags]
    public enum RecordKeys
    {
        [Display(Name="Not Specified")]
        Unspecified = 0,

        [Display(Name="Primary Key")]
        PrimaryKey = 1,

        [Display(Name="Foreign Key")]
        ForeignKey = 2,

        [Display(Name="Multicolumn Key")]
        CombinationKey = 4,

        [Display(Name="External System Key")]
        ExternalSysKey = 8
    }

    /// <summary>
    /// Database operations (CRUD+Lookup)
    /// </summary>
    [Flags]
    public enum RecordOperations
    {
        [Display(Name = "Provides Lookup")]
        Lookup = 0,

        [Display(Name = "Reads Data")]
        SelectsRecords = 1,

        [Display(Name = "Add Records")]
        InsertsRecords = 2,

        [Display(Name="Updates Records")]
        UpdatesRecords = 4,

        [Display(Name="Deletes Records")]
        RemovesRecords = 8,

        [Display(Name="Synchronizes Records")]
        SynchronizesRecords = 15
    }

    /// <summary>
    /// Generic relationships between databases and db servers
    /// </summary>
    public enum InterSystemConnectivity
    {
        [Display(Name="Configured Linked Server")]
        ConfigLinkServer = 0,

        [Display(Name="Cross-System Query")]
        CrossQuery = 1,

        [Display(Name="Replication")]
        Replication,

        [Display(Name="Backup")]
        Backup,

        [Display(Name="Migration")]
        Migration
    }
}
