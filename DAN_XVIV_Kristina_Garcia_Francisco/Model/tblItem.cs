
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------


namespace DAN_XLVIII_Kristina_Garcia_Francisco.Model
{

using System;
    using System.Collections.Generic;
    
public partial class tblItem
{

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public tblItem()
    {

        this.tblShoppingCarts = new HashSet<tblShoppingCart>();

    }


    public int ItemID { get; set; }

    public string ItemName { get; set; }

    public string Price { get; set; }



    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<tblShoppingCart> tblShoppingCarts { get; set; }

}

}
