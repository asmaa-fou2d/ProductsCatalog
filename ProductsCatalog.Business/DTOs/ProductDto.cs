﻿
namespace ProductsCatalog.Business.DTOs
{
    public class ProductDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string CategoryName { get; set; }

        public string Photo { get; set; }

        public double Price { get; set; }

        public int CategoryId { get; set; }

    }
}
