//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ck_project
{
    using System;
    using System.Collections.Generic;
    
    public partial class building_permit
    {
        public int permit_number { get; set; }
        public double adjustable_fee { get; set; }
        public double fixed_fee { get; set; }
        public double start_range { get; set; }
        public double end_range { get; set; }
        public System.DateTime start_date { get; set; }
        public Nullable<System.DateTime> end_date { get; set; }
        public int lead_number { get; set; }
    
        public virtual lead lead { get; set; }
    }
}
