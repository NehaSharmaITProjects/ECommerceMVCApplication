using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineJwellery.Entities
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string ImageUrl { get; set; }
        [NotMapped]
        public  string ImageUrlDescription
        {
            get
            {
                return "~/Images/" + ImageUrl + ".jpg";
            }
        }
        public string Description { get; set; }

        [DataType(DataType.Currency)]
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public bool InStore { get; set; }
       

       

        public List<Review> Review { get; set; }
       
    }
}