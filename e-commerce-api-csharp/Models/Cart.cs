using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace e_commerce_api_csharp.Models
{
    public class Cart
    {
        public Cart()
        {
            this.product = new Product();
        }

        public Cart(Product product, int amount, decimal price)
        {
            this.product = product;
            this.amount = amount;
            this.price = price;
        }

        public Product product { get; set; }
        public int amount { get; set; }
        public decimal price { get; set; }
    }
}
