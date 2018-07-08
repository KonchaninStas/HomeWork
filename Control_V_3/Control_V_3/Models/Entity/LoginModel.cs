using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Control_V_3.Models.Entity
{
    public class LoginModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [UIHint ("password")]
        public string Password { get; set; }
        public string ReturnUrl { get; set; } = "/";
    }
}
