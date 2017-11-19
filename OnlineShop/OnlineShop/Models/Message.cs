using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShop.Models
{
    public class Message
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public ApplicationUser Sender { get; set; }
        public ApplicationUser Recepient { get; set; }
    }
}