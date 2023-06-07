﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VintageHouse.Models
{
    [Table("Product")]
    public class Product
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(40)]
        public string? ProductName { get; set; }

        public string? Description { get; set; }

        [Required]
        public double Price { get; set; }
        public string? Image { get; set; }
        [Required]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public List<OrderDetail> OrderDetail { get; set; }
        public List<CartDetail> CartDetail { get; set; }

        [NotMapped]
        public string CategoryName { get; set; }
    }
}
