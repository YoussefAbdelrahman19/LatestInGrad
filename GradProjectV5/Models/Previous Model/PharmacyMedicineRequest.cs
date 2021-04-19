//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GradProjectV5.Models.Previous_Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class PharmacyMedicineRequest
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PharmacyMedicineRequest()
        {
            this.PhMedicineRequestStatus = new HashSet<PhMedicineRequestStatu>();
        }
    
        public int ID { get; set; }
        public Nullable<int> MedicineId { get; set; }
        public Nullable<int> RequestPharamcyId { get; set; }
        public string Amount { get; set; }
        public Nullable<System.DateTime> RequestDate { get; set; }
        public Nullable<int> RequestStatusId { get; set; }
        public Nullable<int> RespondPharamacyId { get; set; }
        public Nullable<System.DateTime> RespondDate { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public Nullable<int> LatestStatusId { get; set; }
    
        public virtual Medicine Medicine { get; set; }
        public virtual Pharamacy Pharamacy { get; set; }
        public virtual Status Status { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhMedicineRequestStatu> PhMedicineRequestStatus { get; set; }
    }
}
