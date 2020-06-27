using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProductsCatalog.Website.ViewModels
{
    public class SlideshowViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string SubTitle { get; set; }

        public string Photo { get; set; }

        public string Description { get; set; }

        public string Heading
        {
            get
            {
                return (Id != 0) ? "Update Category" : "Add New Category";
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