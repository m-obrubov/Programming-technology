//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OnlineShop.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Order
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Order()
        {
            this.ShoppingCart = new HashSet<ShoppingCart>();
        }
    
        public int Id { get; set; }
        public short Status { get; set; }
        public string BuyerId { get; set; }
        public string ManagerId { get; set; }
        public string DeliveryAddressId { get; set; }
        public short PaymentType { get; set; }
        public bool IsPayed { get; set; }
        public decimal TotalCost { get; set; }
    
        public virtual Address Address { get; set; }
        public virtual Buyer Buyer { get; set; }
        public virtual Employee Employee { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ShoppingCart> ShoppingCart { get; set; }
    }
}
