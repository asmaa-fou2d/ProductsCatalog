
using System.ComponentModel.DataAnnotations;

namespace ProductsCatalog.Website.ViewModels
{
    public class CategoryViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Photo { get; set; }


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