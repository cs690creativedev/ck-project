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
    
    public partial class lead_log_file
    {
        public int log_number { get; set; }
        public string emp_username { get; set; }
        public int lead_number { get; set; }
        public string table_name { get; set; }
        public string column_name { get; set; }
        public string action_name { get; set; }
        public System.DateTime update_date { get; set; }
        public string prvious_value { get; set; }
        public string new_value { get; set; }
    
        public virtual lead lead { get; set; }
    }
}
