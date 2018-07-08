using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Control_V_3.Models.Entity
{/// <summary>
/// Order Entity
/// </summary>
    public class Order
    {
        [BindNever]
        public int OrderId { get; set; }
        [BindNever]
        public ICollection<CartLine> Lines { get; set; }
        [BindNever]
        public bool Shipped { get; set; }
        [Required(ErrorMessage ="Please enter a name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter a surname")]
        public string Surname { get; set; }
        [Required(ErrorMessage ="Please enter the address line")]
        public  string Address { get; set; }
        [Required(ErrorMessage = "Please enter a city name")]
        public string City { get; set; }
        [Required(ErrorMessage = "Please enter a country name")]
        public string Country { get; set; }
        public bool GiftWrap { get; set; }
        public Order()
        {
            Lines = new List<CartLine>();
        }
        //public int OrderId { get; set; }
        //public int? UserId { get; set; }
        //public virtual User User { get; set; }
        //public virtual ICollection<Book> Books { get; set; }
        ///// <summary>
        ///// Standart constructor
        ///// </summary>
        //public Order()
        //{
        //    Books = new List<Book>();
        //}
    }
}
