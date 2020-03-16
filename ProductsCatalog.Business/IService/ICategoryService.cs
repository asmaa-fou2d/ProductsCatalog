using ProductsCatalog.Business.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsCatalog.Business.IService
{
    public interface ICategoryService
    {
        /// <summary>
        /// Get all categories 
        /// </summary>
        /// <returns>list of categories</returns>
        List<CategoryDto> GetAll();

        /// <summary>
        /// Creare category
        /// </summary>
        /// <param name="categoryDto">Category Dto</param>
        void Creare(CategoryDto categoryDto);

        /// <summary>
        /// Get category by Id 
        /// </summary>
        /// <param name="id">Category id</param>
        /// <returns>Category data</returns>
        CategoryDto GetById(int id);

        /// <summary>
        /// Delete category 
        /// </summary>
        /// <param name="id">Category id</param>
        void Delete(int id);

        /// <summary>
        /// Update category
        /// </summary>
        /// <param name="categoryDto">Category Dto</param>
        void Update(CategoryDto CategoryDto);

    }
}
