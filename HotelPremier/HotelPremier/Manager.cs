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
    
    public partial class Manager
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Manager()
        {
            this.Requests = new HashSet<Request>();
            this.Workers = new HashSet<Worker>();
        }
    
        public int ManagerId { get; set; }
        public int HotelUserId { get; set; }
        public int HotelFloor { get; set; }
        public int WorkExperience { get; set; }
        public int QualificationLevelId { get; set; }
    
        public virtual HotelUser HotelUser { get; set; }
        public virtual QualificationLevel QualificationLevel { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Request> Requests { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Worker> Workers { get; set; }
    }
}
