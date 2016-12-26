using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemMap.Enums
{
    [Flags]
    public enum ValueTypes
    {
        [Display(Name="Unspecified Value Type")]
        NotSet = 0,
        [Display(Name="Count")]
        Count = 1,
        [Display(Name="Processing")]
        BigO = 2,
        [Display(Name="Risk")]
        Vulnerability = 4,
        [Display(Name="Likelihood")]
        Probability = 8,
        [Display(Name="Load Factor")]
        LoadFactor = 16,
        [Display(Name="Necessity")]
        Necessity=32
    }
}
