//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NguyenQuangNamK22CNTT2.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class donhang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public donhang()
        {
            this.ctdonhangs = new HashSet<ctdonhang>();
        }
    
        public int donhang_id { get; set; }
        public Nullable<int> khachhang_id { get; set; }
        public Nullable<System.DateTime> ngay { get; set; }
        public Nullable<decimal> tong { get; set; }
        public string trangthai { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ctdonhang> ctdonhangs { get; set; }
        public virtual khachhang khachhang { get; set; }
    }
}
