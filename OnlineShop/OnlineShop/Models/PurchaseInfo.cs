using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShop.Models
{
    public class PurchaseInfo
    {
        public string CardNumber { get; set; }
        public int ExpYear { get; set; }
        public int ExpMonth { get; set; }
        public string CardHolder { get; set; }
        public string CVC { get; set; }
        public decimal Sum { get; set; }
    }
}