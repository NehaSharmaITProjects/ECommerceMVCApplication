using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineJwellery.Entities
{
    public class Basket
    {
        public int Quantity { get; set; }

        public Product Product { get; set; }

        [NotMapped]
        public decimal Amount
        {
            get { return Product.Price * Quantity; }

        }

    }

  
}
