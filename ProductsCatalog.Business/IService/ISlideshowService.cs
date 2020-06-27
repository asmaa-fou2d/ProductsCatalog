using ProductsCatalog.Business.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsCatalog.Business.IService
{
    public interface ISlideshowService
    {
        /// <summary>
        /// Get all slideshow 
        /// </summary>
        /// <returns>list of slideshow</returns>
        List<SlideshowDto> GetAll();

        /// <summary>
        /// Creare slideshow
        /// </summary>
        /// <param name="slideshowDto">slideshow Dto</param>
        void Creare(SlideshowDto slideshowDto);

        /// <summary>
        /// Get slideshow by Id 
        /// </summary>
        /// <param name="id">slideshow id</param>
        /// <returns>slideshow data</returns>
        SlideshowDto GetById(int id);

        /// <summary>
        /// Delete slideshow 
        /// </summary>
        /// <param name="id">slideshow id</param>
        void Delete(int id);

        /// <summary>
        /// Update slideshow
        /// </summary>
        /// <param name="slideshow">slideshow Dto</param>
        void Update(SlideshowDto slideshowDto);
    }
}
