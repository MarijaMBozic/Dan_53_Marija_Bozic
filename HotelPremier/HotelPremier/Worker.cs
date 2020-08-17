//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HotelPremier
{
    using System;
    using System.Collections.Generic;
    
    public partial class Worker
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Worker()
        {
            this.Requests = new HashSet<Request>();
        }
    
        public int WorkerId { get; set; }
        public int ClinicFloor { get; set; }
        public string Citizenship { get; set; }
        public Nullable<decimal> Salary { get; set; }
        public int HotelUserId { get; set; }
        public int GenderId { get; set; }
        public int EngagmentId { get; set; }
        public int ManagerId { get; set; }
    
        public virtual Engagment Engagment { get; set; }
        public virtual Gender Gender { get; set; }
        public virtual HotelUser HotelUser { get; set; }
        public virtual Manager Manager { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Request> Requests { get; set; }
    }
}
