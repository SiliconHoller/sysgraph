//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SystemMap.Entities.data
{
    using System;
    using System.Collections.Generic;
    
    public partial class process_membership
    {
        public int processid { get; set; }
        public int processedge_id { get; set; }
        public Nullable<int> memtypeid { get; set; }
    
        public virtual edge edge { get; set; }
        public virtual membership_types membership_types { get; set; }
        public virtual process process { get; set; }
    }
}
