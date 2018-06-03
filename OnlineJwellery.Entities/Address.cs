using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineJwellery.Entities
{
    public class Address
    {
        public int Id { get; set; }

        public int AddressType { get; set; }
        public string StreetLine1 { get; set; }
        public string StreetLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }

        public ApplicationUser ApplicationUser { get; set; }
        [ForeignKey("ApplicationUser")]
        public string ApplicationUserId { get; set; }
       
    }
}