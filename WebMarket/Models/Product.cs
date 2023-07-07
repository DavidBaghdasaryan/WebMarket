using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
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
        [Required]
        public decimal StartingCost { get; set; }
        [Required]
        public decimal Cost { get; set; }
        [ValidateNever]
        public string ImageUrl { get; set; }
    }
}
