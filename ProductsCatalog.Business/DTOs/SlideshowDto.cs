using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsCatalog.Business.DTOs
{
    public class SlideshowDto
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string SubTitle { get; set; }

        public string Photo { get; set; }

        public string Description { get; set; }
    }
}
