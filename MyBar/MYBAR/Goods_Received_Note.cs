//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MYBAR
{
    using System;
    using System.Collections.Generic;
    
    public partial class Goods_Received_Note
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Goods_Received_Note()
        {
            this.Goods_Received_Note_Details = new HashSet<Goods_Received_Note_Details>();
        }
    
        public int Id { get; set; }
        public string OrderNumber { get; set; }
        public string UserId { get; set; }
        public System.DateTime OrderDate { get; set; }
        public Nullable<System.DateTime> LastUpdateDate { get; set; }
        public int Online_Id { get; set; }
    
        public virtual AspNetUsers AspNetUsers { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Goods_Received_Note_Details> Goods_Received_Note_Details { get; set; }
    }
}
