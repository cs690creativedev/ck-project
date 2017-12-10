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
    using System.ComponentModel.DataAnnotations;

    public partial class installation
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public installation()
        {
            this.rates_installation = new HashSet<rates_installation>();
            this.tasks_installation = new HashSet<tasks_installation>();
        }
    
        public int installation_number { get; set; }
        public string estimated_by { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> statrt_date { get; set; }
        public int lead_number { get; set; }
        public string recommendation { get; set; }
        public Nullable<double> total_miles { get; set; }
        public Nullable<double> required_hotel_nights { get; set; }
        public Nullable<double> hotel_round_trip { get; set; }
        public Nullable<double> installation_days { get; set; }
        public Nullable<double> total_per_diem_cost { get; set; }
        public Nullable<double> total_installation_labor_cost { get; set; }
        public Nullable<double> total_operational_expenses { get; set; }
        public Nullable<double> total_construction_materials_cost { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        public double total_tile_cost { get; set; }
        public Nullable<double> total_travel_cost { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> estimated_date { get; set; }
        public Nullable<double> travel_time_one_way { get; set; }
        public Nullable<double> building_permit_cost { get; set; }
        public Nullable<double> hotel_expense { get; set; }
        public Nullable<double> mileage_expense { get; set; }
        public Nullable<double> tile_installation_days { get; set; }
        public Nullable<double> installation_labor_only_cost { get; set; }
        public Nullable<double> billable_hours { get; set; }
        public Nullable<double> estimated_hours { get; set; }
        [Required]
        [Range(0,999999)]
        public double oneway_mileages_to_destination { get; set; }
        public Nullable<double> ov_labor_rate { get; set; }
        public Nullable<double> ov_material_rate { get; set; }
    
        public virtual lead lead { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<rates_installation> rates_installation { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tasks_installation> tasks_installation { get; set; }
    }
}
