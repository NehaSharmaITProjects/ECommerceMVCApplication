using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineJwellery.Entities
{
    public class OrderItems : Basket
    {

        [Key]
        public int Id { get; set; }



        public Order Order { get; set; }

        public int OrderId { get; set; }

     
        public int ProductId { get; set; }
        
        //public decimal Price { get; set; }


       
    }
}