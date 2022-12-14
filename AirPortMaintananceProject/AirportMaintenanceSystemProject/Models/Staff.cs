//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AirportMaintenanceSystemProject.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Staff
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Staff()
        {
            this.Operations = new HashSet<Operation>();
            this.AssignTasks = new HashSet<AssignTask>();
        }
    
        public int StaffId { get; set; }
        public string StaffName { get; set; }
        public string StaffEmail { get; set; }
        public Nullable<int> StaffPhoneNo { get; set; }
        public string StaffAddress { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Operation> Operations { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AssignTask> AssignTasks { get; set; }
    }
}
