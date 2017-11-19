namespace OnlineShop.Models
{
    public class Order
    {
        public int Id { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public Buyer Buyer { get; set; }
        public Manager Manager { get; set; }
        public ShoppingCart ShoppingCart { get; set; }
        public PaymentType PaymentType { get; set; }
        public bool IsPayed { get; set; }
        public decimal TotalCost { get; set; }
    }

    public enum OrderStatus
    {
        Created,
        Confirmed,
        WaitingForPayment,
        Delivering,
        Delivered,
        Cancelled
    }

    public enum PaymentType
    {
        Cash,
        Cashless
    }

}