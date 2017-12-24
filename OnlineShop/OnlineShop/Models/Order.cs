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
        public int Id { get; set; }
        public short Status { get; set; }
        public string BuyerId { get; set; }
        public string ManagerId { get; set; }
        public int ShoppingCartId { get; set; }
        public string DeliveryAddressId { get; set; }
        public short PaymentType { get; set; }
        public bool IsPayed { get; set; }
        public decimal TotalCost { get; set; }
    
        public virtual Address Address { get; set; }
        public virtual Buyer Buyer { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual ShoppingCart ShoppingCart { get; set; }
    }
}
