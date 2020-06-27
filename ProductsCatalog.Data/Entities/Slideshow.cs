using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsCatalog.Data.Entities
{
    public class Slideshow
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string SubTitle { get; set; }

        [Required]
        public string Photo { get; set; }

        public string Description { get; set; }
    }
}
