using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace WebMarket.Models
{
    public class MarketUser:IdentityUser
    {
        [Required]
        public string Name { get; set; }

        public string? StreetAddres { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? PostalCOde { get; set; }
    }
}
