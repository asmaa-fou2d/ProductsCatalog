using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProductsCatalog.Data.Entities
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Photo { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
