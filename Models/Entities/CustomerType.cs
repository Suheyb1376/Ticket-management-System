using System.ComponentModel.DataAnnotations;

namespace AspnetCoreMvcFull.Models.Entities
{
    public class CustomerType
    {
        [Key]
        public int CustomerId { get; set; }
        public required string Customtype { get; set; }
        public string CustomDescription { get; set; }
    }
}
