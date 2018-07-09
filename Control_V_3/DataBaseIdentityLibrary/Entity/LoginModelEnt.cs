using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataBaseIdentityLibrary.Entity
{
   public class LoginModelEnt
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [UIHint("password")]
        public string Password { get; set; }
        public string ReturnUrl { get; set; } = "/";
    }
}
