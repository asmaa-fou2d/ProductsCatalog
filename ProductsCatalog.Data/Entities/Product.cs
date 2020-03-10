﻿
using System.ComponentModel.DataAnnotations;

namespace ProductsCatalog.Data.Entities
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Photo { get; set; }

        public double Price { get; set; }
    }
}
