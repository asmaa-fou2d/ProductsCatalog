﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProductsCatalog.Website.ViewModels
{
    public class ProductViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string CategoryName { get; set; }

        public string Photo { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        public int CategoryId { get; set; }
        public IEnumerable<CategoryViewModel> CategoriesList { get; set; }


        public string Heading
        {
            get
            {
                return (Id != 0) ? "Update Product" : "Add New Product";
            }
        }

        public string Action
        {
            get
            {
                return (Id != 0) ? "Update" : "Create";
            }
        }

    }
}