using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemMap.Enums
{
    public enum DocTypes
    {
        [Display(Name="Note")]
        Note,
        [Display(Name="Comment")]
        Comment,
        [Display(Name="Wiki")]
        Wiki,
        [Display(Name="Technical Writeup")]
        TechWriteup,
        [Display(Name="User Manual")]
        UserManual,
        [Display(Name="Administration")]
        Admin,
        [Display(Name="Configuration")]
        Configuration,
        [Display(Name="Code Documentation")]
        CodeDocs,
        [Display(Name="Knowledge Base")]
        KnowledgeBase,
        [Display(Name="History")]
        History,
        [Display(Name="General")]
        General
    }
}
