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
    
    public partial class Goods_Dispatch_Note_Details
    {
        public int Id { get; set; }
        public int GDNId { get; set; }
        public int MenuItemId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    
        public virtual Goods_Dispatch_Note Goods_Dispatch_Note { get; set; }
        public virtual MenuItems MenuItems { get; set; }
    }
}
