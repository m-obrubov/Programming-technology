using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShop.Models
{
    public enum OrderStatus
    {
        Created,
        Confirmed,
        WaitingForPayment,
        Delivering,
        Done,
        Cancelled
    }

    public enum PaymentType
    {
        Cash,
        Cashless
    }
}