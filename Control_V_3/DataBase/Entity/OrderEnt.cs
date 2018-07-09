using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataBase.Entity
{
    /// <summary>
    /// Order Entity
    /// </summary>
    public class OrderEnt
    {
        [BindNever]
        public int OrderEntId { get; set; }
        [BindNever]
        public ICollection<CartLineEnt> Lines { get; set; }
        [BindNever]
        public bool Shipped { get; set; }
        [Required(ErrorMessage = "Please enter a name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter a surname")]
        public string Surname { get; set; }
        [Required(ErrorMessage = "Please enter the address line")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Please enter a city name")]
        public string City { get; set; }
        [Required(ErrorMessage = "Please enter a country name")]
        public string Country { get; set; }
        public bool GiftWrap { get; set; }
        public OrderEnt()
        {
            Lines = new List<CartLineEnt>();
        }
    }
}
