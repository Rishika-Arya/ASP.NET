//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System.ComponentModel.DataAnnotations;
namespace AirportMaintenanceSystemProject.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Inspection
    {
        public int InspectionId { get; set; }
        public string Subject { get; set; }
        public string Frequency { get; set; }
        [Required]
        public string Status { get; set; }
        [DataType(DataType.Date)]
       
        public Nullable<System.DateTime> InspectedDate { get; set; }
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> NextDueDate { get; set; }
        public string Review { get; set; }
        public Nullable<int> DepartmentId { get; set; }
    
        public virtual Department Department { get; set; }
    }
}
