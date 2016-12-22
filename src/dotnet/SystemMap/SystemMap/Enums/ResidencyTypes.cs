using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemMap.Enums
{
    public enum ResidencyTypes
    {
        [Display(Name="Component")]
        Component,
        [Display(Name="Installed Software")]
        InstalledSoftware,
        [Display(Name="Host")]
        Host,
        [Display(Name="Service")]
        Service,
        [Display(Name="Sub Process")]
        SubProcess,
        [Display(Name="File")]
        File,
        [Display(Name="Filesystem")]
        Filesystem,
        [Display(Name="Persistent Storage")]
        PersistentStorage
    }
}
