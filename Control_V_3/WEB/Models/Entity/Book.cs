﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Control_V_3.Models.Entity
{
    /// <summary>
    /// Book Entity
    /// </summary>
    public class Book
    {
        public int BookId { get; set; }
        [Required(ErrorMessage = "Please enter а book name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter а description")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Please enter а book author")]
        public string Author { get; set; }
        [Required(ErrorMessage = "Please specify а category")]
        public string Category { get; set; }
        [Required]
        [Range(0, 3000,ErrorMessage = "Please enter а positive number of pages")]
        public int Count { get; set; }
        [Required]
        [Range(0.01, double.MaxValue,ErrorMessage = "Please enter а positive price")]
        public decimal Price { get; set; }
        /// <summary>
        /// Standart constructor
        /// </summary>
        public Book()
        {

        }
    }
}
