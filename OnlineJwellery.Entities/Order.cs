using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineJwellery.Entities
{
    public class Order
    {
        [Display(Name = "Order Number")]
        public string OdrNum { get; set; }

        
      
        //[NotMapped]
        public List<OrderItems> OrderItems { get; set; }

        [NotMapped]
        public string OrderElement
        {
            get
            {
               return "Order_" + Id;
            }
        }
        [NotMapped]
        public string OrderElementId
        {
            get
            {
                return "#Order_" + Id;
            }
        }
        [NotMapped]
        public decimal TotalAmount {
            get
            {
                if (OrderItems != null)
                    return OrderItems.Select(orditems => orditems.Product.Price * orditems.Quantity).Sum();
                else
                    return 0;              
            }
        }
        [Display(Name = "Order Date")]
        public DateTime OrderPlacedDate { get; set; }
        [NotMapped]
        [Display(Name = "Email")]
        public string UserName { get; set; }

        public ApplicationUser ApplicationUser { get; set; }
        [ForeignKey("ApplicationUser")]
        public string ApplicationUserId { get; set; }
        [Key]
        public int Id { get; set; }
    }
}
