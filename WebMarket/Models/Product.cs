using System.ComponentModel.DataAnnotations;

namespace WebMarket.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        public string Tipe { get; set; }
    }
}
