using System;
using System.Linq;
using System.Web;

namespace OnlineShop.Models
{
    public class Address
    {
        public int Id { get; set; }
        public string Postcode { get; set; }
        public string Country { get; set; }
        public string Region { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string House { get; set; }
        public string Flat { get; set; }

        public virtual Buyer Buyer { get; set; }
    }
}