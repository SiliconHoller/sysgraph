using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemMap.Enums
{
    /// <summary>
    /// Cross-DB definitions of Column types
    /// </summary>
    public enum DbColumnAttributes
    {
        [Display(Name="int")]
        DbInteger,
        [Display(Name="Decimal")]
        DbDecimal,
        [Display(Name="VARCHAR")]
        VARCHAR,
        [Display(Name="NVARCHAR")]
        NVARCHAR,
        [Display(Name="bit")]
        BIT,
        [Display(Name="DateTime")]
        DbDateTime,
        [Display(Name="Timestamp")]
        DbTimestamp

    }
}
